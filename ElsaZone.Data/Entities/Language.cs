using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Languages")]
public class Language
{
    public int LanguageId { set; get; }
    public string Name { set; get; }
    public IsDefault IsDefault { set; get; }
    /*==========================================*/
}