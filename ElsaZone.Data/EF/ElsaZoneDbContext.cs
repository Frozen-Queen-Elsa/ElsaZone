using ElsaZone.Data.Configurations;
using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ElsaZone.Data.EF;

public class ElsaZoneDbContext:DbContext
{
    public ElsaZoneDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
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
    }

    public DbSet<Account> Accounts { get; set; }
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