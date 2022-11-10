namespace ElsaZone.Application.Catalog.Dtos.Manage;

public class ProductUpdateRequest
{
    public int ProductId { set; get; }

    public string ProductName { set; get; }

    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }
    
 


}