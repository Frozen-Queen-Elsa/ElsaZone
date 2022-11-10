using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Configurations;

public class ProductImageConfiguration:IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages");

        builder.HasKey(x => x.ProductImageId);
        builder.Property(x => x.ProductImageId).UseIdentityColumn();
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.ImagePath).HasMaxLength(255);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(x => x.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
        builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
        builder.Property(x => x.IsDefault).IsRequired().HasDefaultValue(IsDefault.Normal);


       
    }
}