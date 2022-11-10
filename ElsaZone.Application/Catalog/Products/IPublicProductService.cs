
using ElsaZone.Application.Catalog.Dtos;
using ElsaZone.Application.Catalog.Dtos.Public;
using ElsaZone.Application.Dtos;

namespace ElsaZone.Application.Catalog.Products;

public interface IPublicProductService
{
   Task<PagedResultBase<ProductsViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
}