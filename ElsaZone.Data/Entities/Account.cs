using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;

namespace ElsaZone.Data.Entities;
[Table("Accounts")]
public class Account
{
    public string AccountId { set; get; }
    public string Password { set; get; }
    public string DisplayName { set; get; }
    public string Fullname { set; get; }
    public int Gender { set; get; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Avatar { get; set; }
    public decimal MoneyBalance { set; get; }
    public DateTime CreatedDate { set; get; }
    public DateTime UpdatedDate { set; get; }
    public IsActive IsActive { set; get; }
    public IsDeleted IsDeleted { set; get; }
    public DateTime LastLoginDate { get; set; }
    /*==========================================*/
    public List<Cart> Carts { get; set; }
    public List<Rate> Rates { get; set; }
    

}