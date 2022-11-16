using ElsaZone.Data.EF;
using ElsaZone.Data.Entities;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ElsaZone.Application.Common;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Utilities.Exceptions;
using ElsaZone.ViewModels.Catalog.Product;
using ElsaZone.ViewModels.Catalog.ProductImage;
using ElsaZone.ViewModels.Common;
using Microsoft.AspNetCore.Http;

namespace ElsaZone.Application.Catalog.Products;

public class ProductService:IProductService
{
    private readonly ElsaZoneDbContext _context;
    private readonly IStorageService _storageService;
    private const string USER_CONTENT_FOLDER_NAME = "user-content";
    public ProductService(ElsaZoneDbContext context,IStorageService storageService)
    {
        _context = context;
        _storageService = storageService;
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
            IsDeleted = IsDeleted.Normal,
        };
        //Save Image Default
        if (request.DefaultImage != null)
        {
            product.ProductImages = new List<ProductImage>()
            {
                new ProductImage()
                {
                    Caption = "Thumbnail image",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    FileSize = request.DefaultImage.Length,
                    ImagePath = await this.SaveFile(request.DefaultImage),
                    IsDefault = IsDefault.Default,
                    SortOrder = 1
                }
            };
        }

        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product.ProductId;
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
        if (request.DefaultImage != null)
        {
            var defaultimage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault==IsDefault.Default && i.ProductId == request.ProductId);
            if (defaultimage != null)
            {
                defaultimage.FileSize = request.DefaultImage.Length;
                defaultimage.ImagePath = await this.SaveFile(request.DefaultImage);
                _context.ProductImages.Update(defaultimage);
            }
        }

        return await _context.SaveChangesAsync();
    }

    public async Task<ProductVm> GetById(int ProductId)
    {
        var product = await _context.Products.FindAsync(ProductId);
        var category =  (from c in _context.Categories
                join p in _context.Products on c.CategoryId equals p.CategoryId
                where p.ProductId==ProductId
                    select c.CategoryName
                ).FirstOrDefaultAsync();
        var image = await _context.ProductImages.Where(x => x.ProductId == ProductId && x.IsDefault == IsDefault.Default).FirstOrDefaultAsync();
        var productViewModel = new ProductVm()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            CategoryId = product.CategoryId,
            CategoryName = category.Result,
            Quantity = product.Quantity,
            Discount = product.Discount,
            OriginalPrice = product.OriginalPrice,
            SellPrice = product.SellPrice,
            
            CreatedDate = product.CreatedDate,
            UpdatedDate = product.UpdatedDate,
            SEODescription = product.SEODescription,
            SEOTitle = product.SEOTitle,
            SEOAlias = product.SEOAlias,
            IsDeleted = product.IsDeleted,
            Status = product.Status,
            ViewCount = product.ViewCount,
            ImagePath = image != null ? image.ImagePath : "no-image.jpg"
        };
        return productViewModel;
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

    public async Task<bool> AddViewCount(int ProductId)
    {
        var product = await _context.Products.FindAsync(ProductId);
        
        product.ViewCount += 1;
        return await _context.SaveChangesAsync()>0;
    }


   

    public async Task<bool> UpdateIsDeletedProduct(int ProductId)
    {
        var product = await _context.Products.FindAsync(ProductId);
        if (product == null)
            throw new ElsazoneException(($"Can not find a product: {ProductId}"));
        product.IsDeleted =IsDeleted.Deleted;
        return await _context.SaveChangesAsync()>0;
    }

    public async Task<int> AddImage(int ProductId, ProductImageCreateRequest request)
    {
        var productImage = new ProductImage()
        {
            Caption = request.Caption,
            CreatedDate = DateTime.Now,
            IsDefault = IsDefault.Normal,
            ProductId = ProductId,
            SortOrder = request.SortOrder
        };

        if (request.ImageFile != null)
        {
            productImage.ImagePath = await this.SaveFile(request.ImageFile);
            productImage.FileSize = request.ImageFile.Length;
        }
        _context.ProductImages.Add(productImage);
        await _context.SaveChangesAsync();
        return productImage.ProductImageId;
    }

    public async Task<int> RemoveImage(int ProductImageId)
    {
        var productImage = await _context.ProductImages.FindAsync(ProductImageId);
        if (productImage == null)
            throw new ElsazoneException($"Cannot find an image with id {ProductImageId}");
        _context.ProductImages.Remove(productImage);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> UpdateImage(int ProductImageId, ProductImageUpdateRequest request)
    {
        var productImage = await _context.ProductImages.FindAsync(ProductImageId);
        if (productImage == null)
            throw new ElsazoneException($"Cannot find an image with id {ProductImageId}");

        if (request.ImageFile != null)
        {
            productImage.ImagePath = await this.SaveFile(request.ImageFile);
            productImage.FileSize = request.ImageFile.Length;
            productImage.UpdatedDate=DateTime.Now;
        }
        _context.ProductImages.Update(productImage);
        return await _context.SaveChangesAsync();
    }

    public async Task<ProductImageViewModel> GetImageById(int ProductImageId)
    {
        var image = await _context.ProductImages.FindAsync(ProductImageId);
        if (image == null)
            throw new ElsazoneException($"Cannot find an image with id {ProductImageId}");

        var viewModel = new ProductImageViewModel()
        {
            Caption = image.Caption,
            CreatedDate = image.CreatedDate,
            FileSize = image.FileSize,
            ProductImageId = image.ProductImageId,
            ImagePath = image.ImagePath,
            IsDefault = image.IsDefault,
            ProductId = image.ProductId,
            SortOrder = image.SortOrder
        };
        return viewModel;
    }

    public async Task<List<ProductImageViewModel>> GetListImages(int ProductId)
    {
        return await _context.ProductImages.Where(x => x.ProductId == ProductId)
            .Select(i => new ProductImageViewModel()
            {
                Caption = i.Caption,
                CreatedDate = i.CreatedDate,
                FileSize = i.FileSize,
                ProductImageId = i.ProductImageId,
                ImagePath = i.ImagePath,
                IsDefault = i.IsDefault,
                ProductId = i.ProductId,
                SortOrder = i.SortOrder
            }).ToListAsync();
    }


    public async Task<PagedResultBase<ProductsViewModel>> GetAllPaging(GetManageProductPagingRequest request)
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
           
                    CreatedDate = x.p.CreatedDate,
                    UpdatedDate = x.p.UpdatedDate,
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

    private async Task<string> SaveFile(IFormFile file)
    {
        var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
        await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
       
        return "/" + "USER_CONTENT_FOLDER_NAME" + "/" + fileName;
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
                UpdatedDate = x.p.UpdatedDate,
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

    public async Task<List<ProductsViewModel>> GetAll()
    {
        var query = from p in _context.Products
            join c in _context.Categories on p.CategoryId equals c.CategoryId
            select new { p, c };
        
        var data = await query
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
                UpdatedDate = x.p.UpdatedDate,
                IsDeleted = x.p.IsDeleted,
                Status = x.p.Status,
                ViewCount = x.p.ViewCount,
                
            }).ToListAsync();
        return data;
    }
}