using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Cateogories")]
public class Category
{
    public int CategoryId { set; get; }
    public string Name { set; get; }
    public string Description { set; get; }
    public bool IsDeleted { set; get; }

    public Status Status { set; get; }

}