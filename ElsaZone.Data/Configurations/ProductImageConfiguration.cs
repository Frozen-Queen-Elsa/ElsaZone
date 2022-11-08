using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class ProductImageConfiguration:IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages");

        builder.HasKey(x => x.ProductImageId);
        builder.Property(x => x.ProductImageId).UseIdentityColumn();
        builder.Property(x => x.ProductId).IsRequired(true);

        

       
    }
}