using System.ComponentModel.DataAnnotations.Schema;

namespace ElsaZone.Data.Entities;
[Table("BillDetails")]
public class BillDetail
{
    public int BillDetailId { set; get; }
    public int BillId { set; get; }
    public int ProductId { set; get; }
    public int Quantity { set; get; }
    public decimal SellPrice { set; get; }
    public int PromoteId { set; get; }
    public decimal Discount { set; get; }
    public decimal ResultPrice { set; get; }
    /*==========================================*/
}