using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Configurations;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductId).UseIdentityColumn();
        builder.Property(x => x.CategoryId).IsRequired(true);
        builder.Property(x => x.ProductName).IsRequired(true).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.OriginalPrice).IsRequired(true);
        builder.Property(x => x.SEODescription).IsRequired(false).IsUnicode().HasColumnType("ntext");
        builder.Property(x => x.SEOTitle).IsRequired(false).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.SEOAlias).IsRequired(true).HasMaxLength(50).IsUnicode();
        builder.Property(x => x.Quantity).IsRequired(true);
        builder.Property(x => x.SellPrice).IsRequired(true);
        //builder.Property(x => x.Image).HasMaxLength(255).IsUnicode(false);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
        builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        builder.Property(x => x.ViewCount).IsRequired().HasDefaultValue(0);
    }
}