using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.CategoryId);
        builder.Property(x => x.CategoryId).UseIdentityColumn();
        builder.Property(x => x.CategoryName).IsRequired(true).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.IsHided).IsRequired().HasDefaultValue(IsHided.Normal);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.Active);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(100).IsUnicode(true);



    }
}