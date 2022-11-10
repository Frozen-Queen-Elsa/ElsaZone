
using ElsaZone.ViewModels.Catalog.Product;
using ElsaZone.ViewModels.Catalog.Product.Public;
using ElsaZone.ViewModels.Common;

namespace ElsaZone.Application.Catalog.Products;

public interface IPublicProductService
{
   Task<PagedResultBase<ProductsViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
}