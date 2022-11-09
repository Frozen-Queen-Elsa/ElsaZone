using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.Contact;

namespace ElsaZone.Data.Entities;
[Table("Contacts")]
public class Contact
{
    public int ContactId { set; get; }
    public string Name { set; get; }
    public string Email { set; get; }
    public string PhoneNumber { set; get; }
    public string Message { set; get; }
    public ReadStatus ReadStatus { set; get; }
    /*==========================================*/
}
