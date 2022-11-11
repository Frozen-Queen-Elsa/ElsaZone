using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class AdminConfiguration:IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.HasKey(x => x.AdminId);
        builder.Property(x => x.AdminId).UseIdentityColumn();
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50).IsUnicode(false);
        builder.Property(x => x.Username).IsRequired(true).HasMaxLength(50).IsUnicode(false);
        builder.Property(x => x.Fullname).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsUnicode(false);
        builder.Property(x => x.Address).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Ward).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.District).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Province).IsRequired(false).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Email).HasMaxLength(100).IsUnicode(false);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(IsActive.Offline);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
    }
}