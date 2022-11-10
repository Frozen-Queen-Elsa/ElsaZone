using ElsaZone.Application.Catalog.Dtos;
using ElsaZone.Application.Catalog.Dtos.Manage;
using ElsaZone.Application.Catalog.Products.Manage;
using ElsaZone.Application.Dtos;
using ElsaZone.Data.EF;
using ElsaZone.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Utilities.Exceptions;

namespace ElsaZone.Application.Catalog.Products;

public class ManageProductService:IManageProductService
{
    private readonly ElsaZoneDbContext _context;
    public ManageProductService(ElsaZoneDbContext context)
    {
        _context = context;
    }


    public async Task<int> Create(ProductCreateRequest request)
    {
        var product = new Product()
        {
            CategoryId = request.CategoryId,
            ProductName = request.ProductName,
            OriginalPrice = request.OriginalPrice,
            SellPrice = request.SellPrice,
            Quantity = request.Quantity,
            Discount = request.Discount,
            ViewCount = 0,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            SEOAlias = request.SEOAlias,
            SEODescription = request.SEODescription,
            SEOTitle = request.SEOTitle,
            Status = Status.Active,
            IsDeleted = IsDeleted.Normal
        };
        _context.Products.Add(product);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(ProductUpdateRequest request)
    {
        var product = _context.Products.Find(request.ProductId);
        if (product == null) throw new ElsazoneException($"Can't find the product with id: {request.ProductId}");
        product.ProductName = request.ProductName;
        product.SEOAlias = request.SEOAlias;
        product.SEODescription = request.SEODescription;
        product.SEOTitle = request.SEOTitle;
        product.UpdatedDate=DateTime.Now;
      
     
        return await _context.SaveChangesAsync();
    }

    public async Task<bool> UpdateSellPrice(int ProductId, decimal newSellPrice)
    {
        var product = _context.Products.Find(ProductId);
        if (product == null) throw new ElsazoneException($"Can't find the product with id: {ProductId}");
        product.SellPrice = newSellPrice;
        product.UpdatedDate=DateTime.Now;
     
        return await _context.SaveChangesAsync()>0;
    }

    public async Task<bool> UpdateDiscount(int ProductId, decimal newDiscount)
    {
        var product = _context.Products.Find(ProductId);
        if (product == null) throw new ElsazoneException($"Can't find the product with id: {ProductId}");
        product.Discount = newDiscount;
        product.UpdatedDate=DateTime.Now;
     
        return await _context.SaveChangesAsync()>0;
    }

    public async Task<bool> UpdateQuantity(int ProductId, int newQuantity)
    {
        var product = _context.Products.Find(ProductId);
        if (product == null) throw new ElsazoneException($"Can't find the product with id: {ProductId}");
        product.Quantity = newQuantity;
        product.UpdatedDate=DateTime.Now;
     
        return await _context.SaveChangesAsync()>0;
    }

    public async Task AddViewCount(int ProductId)
    {
        var product = await _context.Products.FindAsync(ProductId);
        
        product.ViewCount += 1;
        await _context.SaveChangesAsync();
    }


   

    public async Task UpdateIsDeleteProduct(int ProductId)
    {
        var product = await _context.Products.FindAsync(ProductId);
        if (product == null)
            throw new ElsazoneException(($"Can not find a product: {ProductId}"));
        product.IsDeleted =IsDeleted.Deleted;
        await _context.SaveChangesAsync();
    }



    public async Task<PagedResultBase<ProductsViewModel>> GetAllPaging(GetProductPagingRequest request)
    {
        //1. Select join
            var query = from p in _context.Products
                        join c in _context.Categories on p.CategoryId equals c.CategoryId
                        select new { p, c };
            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.ProductName.Contains(request.Keyword));

            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(p => p.c.CategoryId == request.CategoryId);
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductsViewModel()
                {
                    ProductId =  x.p.ProductId,
                    ProductName = x.p.ProductName,
                    CategoryName = x.c.CategoryName,
                    OriginalPrice = x.p.OriginalPrice,
                    SellPrice = x.p.OriginalPrice,
                    Discount = x.p.Discount,
                    SEOAlias = x.p.SEOAlias,
                    SEODescription = x.p.SEODescription,
                    SEOTitle = x.p.SEOTitle,
                    Image=x.p.Image,
                    CreatedDate = x.p.CreatedDate,
                    UpdatedDate = x.p.CreatedDate,
                    IsDeleted = x.p.IsDeleted,
                    Status = x.p.Status,
                    ViewCount = x.p.ViewCount,
                    
        
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResultBase<ProductsViewModel>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
    }
}