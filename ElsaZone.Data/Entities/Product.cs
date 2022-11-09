using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Products")]
public class Product
{
    public int ProductId { set; get; }
    public int CategoryId { set; get; }
    public string Name { set; get; }
    public int Quantity { get; set; }
    public decimal OriginalPrice { get; set; }
    public decimal Discount { set; get; }
    public decimal SellPrice { set; get; }
    public string Image { set; get; }
    public string SEOTitle { set; get; }
    public string SEODescription { set; get; }
    public string SEOAlias { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedTime { set; get; }
    public bool IsDeleted { set; get; }
    public Status Status { get; set; }
    public int ViewCount { get; set; }

}