using ElsaZone.ViewModels.Common;

namespace ElsaZone.ViewModels.Catalog.Product;

public class GetPublicProductPagingRequest:PagingRequestBase
{
    public int? CategoryId { get; set; }
}