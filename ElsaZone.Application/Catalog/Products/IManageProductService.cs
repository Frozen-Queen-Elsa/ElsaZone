
using ElsaZone.ViewModels.Catalog.Product;
using ElsaZone.ViewModels.Catalog.Product.Manage;
using ElsaZone.ViewModels.Catalog.Product.Public;
using ElsaZone.ViewModels.Catalog.ProductImage;
using ElsaZone.ViewModels.Common;
using Microsoft.AspNetCore.Http;

namespace ElsaZone.Application.Catalog.Products.Manage;

public interface IManageProductService
{
    Task<int> Create(ProductCreateRequest request);
    Task<int> Update(ProductUpdateRequest request);

    Task<bool> UpdateSellPrice(int ProductId, decimal newSellPrice);
    Task<bool> UpdateDiscount(int ProductId, decimal newDiscount);
    Task<bool> UpdateQuantity(int ProductId, int newQuantity);
    Task AddViewCount(int ProductId);
    Task UpdateIsDeleteProduct(int ProductId);
    Task<int> AddImage(int productId, ProductImageCreateRequest request);
    Task<int> RemoveImage(int ProductImageId);
    Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
    Task<ProductImageViewModel> GetImageById(int ProductImageId);
    Task<List<ProductImageViewModel>> GetListImages(int ProductId);

    Task<PagedResultBase<ProductsViewModel>> GetAllPaging(GetProductPagingRequest request);
    
}