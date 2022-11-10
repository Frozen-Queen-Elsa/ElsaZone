using ElsaZone.Application.Dtos;

namespace ElsaZone.Application.Catalog.Dtos.Public;

public class GetPublicProductPagingRequest:PagingRequestBase
{
    public int? CategoryId { get; set; }
}