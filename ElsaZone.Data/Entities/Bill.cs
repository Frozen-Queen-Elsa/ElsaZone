using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.Payment;

namespace ElsaZone.Data.Entities;
[Table("Bills")]
public class Bill
{
    public int BillId { set; get; }
    public string BillCode { set; get; }
    public string Name { set; get; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { set; get; }
    public string Ward { set; get; }
    public string District { set; get; }
    public string Province { set; get; }
    public DateTime CreatedDate { set; get; }
    public string Note { set; get; }
    public int TotalItems { get; set; }
    public decimal TotalAmount { get; set; }
    public int PaidMethod { get; set; }
    public IsDeleted IsDeleted { set; get; }
    public int DeliveredStatus { get; set; }
    /*==========================================*/
}