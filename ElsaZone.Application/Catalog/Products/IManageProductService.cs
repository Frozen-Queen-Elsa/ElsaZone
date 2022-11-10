using ElsaZone.Application.Catalog.Dtos;
using ElsaZone.Application.Dtos;
using System.Threading.Tasks;
using ElsaZone.Application.Catalog.Dtos.Manage;

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

    Task<PagedResultBase<ProductsViewModel>> GetAllPaging(GetProductPagingRequest request);
    
}