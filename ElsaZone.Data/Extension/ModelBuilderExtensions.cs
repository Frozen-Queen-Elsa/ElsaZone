using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;
using ElsaZone.Data.Enums.Promote;
using ElsaZone.Utilities.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace ElsaZone.Data.Extension;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // any guid
        var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
        var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
        var userId = new Guid("3E41E8AB-CCEA-41B1-B254-5157BEDF139B");
        
        modelBuilder.Entity<AppRole>().HasData(
            new AppRole
            {
                Id = adminId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            },
            new AppRole
            {
                Id = userId,
                Name = "user",
                NormalizedName = "User",
                Description = "User role"
            });

        var hasher = new PasswordHasher<AppUser>();

        modelBuilder.Entity<AppUser>().HasData(
            new AppUser()
            {
                Id = userId,
                UserName = "admin",
                NormalizedUserName = "admin",
                PasswordHash = hasher.HashPassword(null, "123"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true,
                DisplayName = "Admin",
                Fullname = "Admin",
                Gender = Gender.Female,
                Email="admin@gmail.com",
                NormalizedEmail ="admin@gmail.com",
                DOB=new DateTime(1992,03,09),
                PhoneNumber="0123456789",
                Avatar = "123",
                MoneyBalance = 987654321,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                
                IsDeleted = IsDeleted.Normal,
                IsActive = IsActive.Offline
            },
            new AppUser()
            {
                Id = userId,
                UserName = "Elsa",
                NormalizedUserName = "elsa",
                PasswordHash = hasher.HashPassword(null, "123"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true,
                DisplayName = "Frozen Queen Elsa",
                Fullname = "Frozen Queen Elsa",
                Gender = Gender.Female,
                Email="FrozenQueenElsa@gmail.com",
                NormalizedEmail = "frozenqueenelsa@gmail.com",
                DOB=new DateTime(1992,03,09),
                PhoneNumber="0123456789",
                Avatar = "123",
                MoneyBalance = 987654321,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                
                IsDeleted = IsDeleted.Normal,
                IsActive = IsActive.Offline
            });
     
        modelBuilder.Entity<Admin>().HasData(
            new Admin()
            {
                AdminId = 1,
                Username = "superadmin",
                Password = MD5Helper.MD5Hash("123"),
                Fullname = "Super Admin",
                Address = "123",
                Ward = "Phường 3",
                District = "Quận 1",
                Province = "TPHCM",
                DOB=new DateTime(1992,03,09),
                Gender = Gender.Female,
                Email="admin@gmail.com",
                PhoneNumber="0123456789",
                Role = Role.SuperAdmin,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Salary = 123456789,
                Fine=0,
                IsDeleted = IsDeleted.Normal,
                IsActive = IsActive.Offline,
                Description="Boss"
            });
        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                CategoryName =  "Sneaker",
                Description = "Giày Sneaker",
                IsDeleted = IsDeleted.Normal,
                IsHided = IsHided.Normal,
                Status = Status.Active
            });
        modelBuilder.Entity<Language>().HasData(
            new Language()
            {
                LanguageId = 1,
                Name = "Việt Nam",
                IsDefault = IsDefault.Normal
            },
            new Language()
            {
                LanguageId = 2,
                Name = "English",
                IsDefault = IsDefault.Default
            });
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                ProductId = 1,
                CategoryId = 1,
                ProductName = "Balenciaga Triple S Sneaker White",
                Quantity = 30,
                OriginalPrice = 20000000,
                Discount = 0,
                SellPrice = 25499000,
                //Image = null,
                SEOTitle = "WhiteBalen",
                SEODescription = "ABC",
                SEOAlias = "SnBaTrSSnWhite",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = IsDeleted.Normal,
                Status = Status.Active,
                ViewCount = 0
            },
            new Product()
            {
                ProductId = 2,
                CategoryId = 1,
                ProductName = "Balenciaga Triple S Sneaker Black",
                Quantity = 15,
                OriginalPrice = 21000000,
                Discount = 0,
                SellPrice = 27599000,
                //Image = null,
                SEOTitle = "BlackBalen",
                SEODescription = "abc",
                SEOAlias = "SnBaTrSSnBlack",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsDeleted = IsDeleted.Normal,
                Status = Status.Active,
                ViewCount = 0
            });
        modelBuilder.Entity<Promote>().HasData(
            new Promote()
            {
                PromoteId = 1,
                Description = "Black Friday Sale",
                Name = "Black Friday",
                CreatedDate = DateTime.Now,
                UpdatedTime = DateTime.Now,
                DiscountType = DiscountType.Percent,
                DiscountValue = 30,
                BeginDate = new DateTime(2022,11,25,00,00,00),
                ExpireDate = new DateTime(2022,11,25,23,59,59),
                ApplyForAll = true,
                ApplyForCategories = "123",
                ApplyForProductIds = "123",
                PromoteStatus = PromoteStatus.Waiting,
                IsDeleted = false
            });
    }
}