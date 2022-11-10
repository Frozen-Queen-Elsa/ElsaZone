
using ElsaZone.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Utilities.Exceptions;
using ElsaZone.ViewModels.Catalog.Product;
using ElsaZone.ViewModels.Catalog.Product.Public;
using ElsaZone.ViewModels.Common;
using Microsoft.Extensions.Configuration;
namespace ElsaZone.Application.Catalog.Products;

public class PublicProductService:IPublicProductService
{
    private readonly ElsaZoneDbContext _context;
    public PublicProductService(ElsaZoneDbContext context)
    {
        _context = context;
    }
    public async Task<PagedResultBase<ProductsViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
    {
        //1. Select join
        var query = from p in _context.Products
            join c in _context.Categories on p.CategoryId equals c.CategoryId
            select new { p, c };
        //2. filter


        if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
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
                CategoryName=x.c.CategoryName,
                OriginalPrice = x.p.OriginalPrice,
                SellPrice = x.p.OriginalPrice,
                Discount = x.p.Discount,
                SEOAlias = x.p.SEOAlias,
                SEODescription = x.p.SEODescription,
                SEOTitle = x.p.SEOTitle,
    
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