using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("ProductImages")]
public class ProductImage
{
    public int ProductImageId { set; get; }
    public int ProductId { set; get; }
    public string Image { set; get; }
    public int CreatedDate { get; set; }
    public decimal UpdatedDate { get; set; }
    public IsDeleted IsDeleted { set; get; }
    /*==========================================*/
    public Product Product { get; set; }
}