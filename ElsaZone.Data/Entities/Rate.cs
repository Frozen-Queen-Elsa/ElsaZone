using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Rates")]
public class Rate
{
    public int RateId { set; get; }
    public int ProductId { set; get; }
    public string AccountId { set; get; }
    public decimal Star { set; get; }
    public string Comment { set; get; }
    public DateTime CreatedDate { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public string Description { set; get; }
    public Product Product { get; set; }
    public Account Account { get; set; }
}