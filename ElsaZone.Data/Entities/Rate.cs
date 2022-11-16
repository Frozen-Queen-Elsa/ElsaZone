using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Rates")]
public class Rate
{
    public int RateId { set; get; }
    public int ProductId { set; get; }
    public string UserName { set; get; }
    public decimal Star { set; get; }
    public string Comment { set; get; }
    public DateTime CreatedDate { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public string Description { set; get; }
    public Product Product { get; set; }
    public AppUser AppUser { get; set; }
}