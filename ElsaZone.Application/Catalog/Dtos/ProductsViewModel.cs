using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Application.Catalog.Dtos;

public class ProductsViewModel
{
    public int ProductId { set; get; }

    public string CategoryName { set; get; }
    public string ProductName { set; get; }
    public int Quantity { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Discount { set; get; }
    public decimal SellPrice { set; get; }
    public string Image { set; get; }
    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedDate { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public Status Status { get; set; }
    public int ViewCount { get; set; }
    
}