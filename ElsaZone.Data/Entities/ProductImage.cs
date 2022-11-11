using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("ProductImages")]
public class ProductImage
{
    public int ProductImageId { set; get; }
    public int ProductId { set; get; }
    public string Caption { get; set; }
    public string ImagePath { set; get; }
    public long FileSize { get; set; }
    
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public IsDefault IsDefault { get; set; }
    public int SortOrder { get; set; }
    
    /*==========================================*/
    public Product Product { get; set; }
}