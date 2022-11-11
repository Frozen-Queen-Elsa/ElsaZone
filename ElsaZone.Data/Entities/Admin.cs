using System.ComponentModel.DataAnnotations.Schema;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;

namespace ElsaZone.Data.Entities;
[Table("Admins")]
public class Admin
{
    public int AdminId { set; get; }
    public string Fullname { set; get; }
    public string Username { set; get; }
    public string Password { set; get; }
    public string Address { set; get; }
    public string Ward { set; get; }
    public string District { set; get; }
    public string Province { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedDate { set; get; }
    public int Gender { set; get; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public int Role { get; set; }
    public decimal Salary { set; get; }
    public decimal Fine { set; get; }
    public string Description { get; set; }
    public IsActive IsActive { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public DateTime LastLoginDate { get; set; }
    /*==========================================*/
    public List<SystemLog> SystemLogs { get; set; }
}