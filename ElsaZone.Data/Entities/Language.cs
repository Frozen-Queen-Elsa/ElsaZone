using System.ComponentModel.DataAnnotations.Schema;

namespace ElsaZone.Data.Entities;
[Table("Languages")]
public class Language
{
    public int LanguageId { set; get; }
    public string Name { set; get; }
    public bool IsDefault { set; get; }
}