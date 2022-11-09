using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class AccountConfiguration:IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(x => x.AccountId);

        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Username).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Phone).HasMaxLength(15);
        
    }
}