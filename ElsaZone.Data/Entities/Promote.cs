using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Promote;

namespace ElsaZone.Data.Entities;
[Table("Promotes")]
public class Promote
{
    public int PromoteId { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedTime { set; get; }
    public DiscountType DiscountType { set; get; }
    public decimal DiscountValue { set; get; }
    public DateTime BeginDate { set; get; }
    public DateTime ExpireDate { set; get; }
    public bool IsDeleted { set; get; }
    public bool ApplyForAll { set; get; }
    public string ApplyForProductIds { set; get; }
    public string ApplyForCategories { set; get; }
    public PromoteStatus PromoteStatus { get; set; }

}