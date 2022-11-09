using System.ComponentModel.DataAnnotations.Schema;

namespace ElsaZone.Data.Entities;
[Table("Rates")]
public class Rate
{
    public int RateId { set; get; }
    public int ProductId { set; get; }
    public int AccountId { set; get; }
    public decimal Star { set; get; }
    public string Comment { set; get; }
    public DateTime CreatedDate { set; get; }
    public bool IsDeleted { set; get; }
    public string Description { set; get; }

}