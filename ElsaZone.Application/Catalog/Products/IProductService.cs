using ElsaZone.ViewModels.Catalog.Product;
using ElsaZone.ViewModels.Catalog.ProductImage;
using ElsaZone.ViewModels.Common;

namespace ElsaZone.Application.Catalog.Products;

public interface IProductService
{
    Task<int> Create(ProductCreateRequest request);
    Task<int> Update(ProductUpdateRequest request);
    Task<ProductVm> GetById(int ProductId);

    Task<bool> UpdateSellPrice(int ProductId, decimal newSellPrice);
    Task<bool> UpdateDiscount(int ProductId, decimal newDiscount);
    Task<bool> UpdateQuantity(int ProductId, int newQuantity);
    Task<bool> AddViewCount(int ProductId);
    Task<bool> UpdateIsDeletedProduct(int ProductId);
    Task<int> AddImage(int productId, ProductImageCreateRequest request);
    Task<int> RemoveImage(int ProductImageId);
    Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
   
    Task<ProductImageViewModel> GetImageById(int ProductImageId);
    Task<List<ProductImageViewModel>> GetListImages(int ProductId);

    Task<PagedResultBase<ProductsViewModel>> GetAllPaging(GetManageProductPagingRequest request);
    Task<PagedResultBase<ProductsViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    Task<List<ProductsViewModel>> GetAll();
}