using ElsaZone.ViewModels.Common;

namespace ElsaZone.ViewModels.Catalog.Product;

public class GetManageProductPagingRequest:PagingRequestBase
{
    public string Keyword { get; set; }
    public int CategoryId { get; set; }
}