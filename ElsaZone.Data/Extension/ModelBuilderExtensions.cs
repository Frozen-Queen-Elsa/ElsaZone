using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;
using ElsaZone.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace ElsaZone.Data.Extension;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var hasher = new PasswordHasher<Account>();
        modelBuilder.Entity<Account>().HasData(
            new Account()
            {
                AccountId = "meangirl",
                Password = MD5Helper.MD5Hash("123"),
                Username = "Frozen Queen Elsa",
                Fullname = "Frozen Queen Elsa",
                Gender = Gender.Female,
                Email="FrozenQueenElsa@gmail.com",
                DOB=new DateTime(1992,03,09),
                Phone="0123456789",
                Avatar = null,
                MoneyBalance = 987654321,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                
                IsDeleted = false,
                IsActive = IsActive.Offline
            });
     
        modelBuilder.Entity<Admin>().HasData(
            new Admin()
            {
                AdminId = 1,
                Username = "superadmin",
                Password = MD5Helper.MD5Hash("123"),
                Fullname = "Super Admin",
                Address = null,
                Ward = null,
                District = null,
                Province = null,
                DOB=new DateTime(1992,03,09),
                Gender = Gender.Female,
                Email="admin@gmail.com",
                Phone="0123456789",
                Role = Role.SuperAdmin,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Salary = 123456789,
                Fine=0,
                IsDeleted = false,
                IsActive = IsActive.Offline
        
            });
        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                Name = "Figure",
                Description = "Tượng",
                IsDeleted = false,
                IsHided = false,
                Status = Status.Active
            });
    }
}