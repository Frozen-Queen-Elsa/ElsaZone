using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Entities;
[Table("Contacts")]
public class Contact
{
    public int ContactId { set; get; }
    public string Name { set; get; }
    public string Email { set; get; }
    public string PhoneNumber { set; get; }
    public string Message { set; get; }
    public Status Status { set; get; }
}