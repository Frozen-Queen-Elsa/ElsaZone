using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Products")]
public class Product
{
    public int ProductId { set; get; }
    public int CategoryId { set; get; }
    public string ProductName { set; get; }
    public int Quantity { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Discount { set; get; }
    public decimal SellPrice { set; get; }
    //public string Image { get; set; }
    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedDate { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public Status Status { get; set; }
    public int ViewCount { get; set; }
    /*==========================================*/
    public List<Cart> Carts { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public Category Category { get; set; }
    public List<Rate> Rates { get; set; }
    
}