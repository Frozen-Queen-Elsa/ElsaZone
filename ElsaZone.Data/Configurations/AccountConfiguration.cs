using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;
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
        builder.Property(x => x.DisplayName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Fullname).HasMaxLength(100);
        
        builder.Property(x => x.Email).HasMaxLength(100);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(IsActive.Offline);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
    }
}