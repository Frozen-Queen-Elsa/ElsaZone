using ElsaZone.Application.Dtos;

namespace ElsaZone.Application.Catalog.Dtos.Manage;

public class GetProductPagingRequest:PagingRequestBase
{
    public string Keyword { get; set; }
    public int CategoryId { get; set; }
}