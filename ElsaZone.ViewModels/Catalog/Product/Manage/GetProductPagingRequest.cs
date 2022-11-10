using ElsaZone.ViewModels.Common;

namespace ElsaZone.ViewModels.Catalog.Product.Manage;

public class GetProductPagingRequest:PagingRequestBase
{
    public string Keyword { get; set; }
    public int CategoryId { get; set; }
}