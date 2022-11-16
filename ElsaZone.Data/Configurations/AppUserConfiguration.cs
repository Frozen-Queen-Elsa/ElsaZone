using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElsaZone.Data.Configurations;

public class AppUserConfiguration: IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x => x.DisplayName).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Fullname).IsRequired(false).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.Avatar).IsRequired(false).HasMaxLength(255).IsUnicode(false);
       
        builder.Property(x => x.CreatedDate).IsRequired().IsRequired(false).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(IsActive.Offline);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
       
    }
}