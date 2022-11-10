using ElsaZone.ViewModels.Common;

namespace ElsaZone.ViewModels.Catalog.Product.Public;

public class GetPublicProductPagingRequest:PagingRequestBase
{
    public int? CategoryId { get; set; }
}