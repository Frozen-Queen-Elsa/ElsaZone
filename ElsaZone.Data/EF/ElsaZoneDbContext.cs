using System.Security.Cryptography;
using ElsaZone.Data.Configurations;
using ElsaZone.Data.Entities;
using ElsaZone.Data.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ElsaZone.Data.EF;

public class ElsaZoneDbContext: IdentityDbContext<AppUser, AppRole, Guid>
{
    public ElsaZoneDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure using Fluent API
   
        modelBuilder.ApplyConfiguration(new AdminConfiguration());
        modelBuilder.ApplyConfiguration(new BillConfiguration());
        modelBuilder.ApplyConfiguration(new BillDetailConfiguration());
        modelBuilder.ApplyConfiguration(new CartConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new LanguageConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
        modelBuilder.ApplyConfiguration(new PromoteConfiguration());
        modelBuilder.ApplyConfiguration(new RateConfiguration());
        modelBuilder.ApplyConfiguration(new SystemLogConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);

        //Data seeding
        modelBuilder.Seed();
    }

    
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<BillDetail> BillDetails { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Promote> Promotes { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<SystemLog> SystemLogs { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

}