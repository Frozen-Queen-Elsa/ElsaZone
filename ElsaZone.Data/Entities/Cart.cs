using System.ComponentModel.DataAnnotations.Schema;

namespace ElsaZone.Data.Entities;
[Table("Carts")]
public class Cart
{
    public int CartId { set; get; }
    public string AccountId { set; get; }
    public int ProductId { set; get; }
    public int Quantity { set; get; }
    public decimal Price { set; get; }
    /*==========================================*/
    public Product Product { get; set; }
    public Account Account { get; set; }
    
}