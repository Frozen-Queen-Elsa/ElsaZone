using Microsoft.AspNetCore.Http;

namespace ElsaZone.ViewModels.Catalog.Product;

public class ProductUpdateRequest
{
    public int ProductId { set; get; }

    public string ProductName { set; get; }

    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }

    public IFormFile DefaultImage { get; set; }

 


}