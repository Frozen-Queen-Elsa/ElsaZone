using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class ProductConfiguration:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.ProductId).UseIdentityColumn();
        builder.Property(x => x.CategoryId).IsRequired(true);
        builder.Property(x => x.OriginalPrice).IsRequired(true);
        builder.Property(x => x.SEOAlias).IsRequired(true);
        builder.Property(x => x.Quantity).IsRequired(true);
        builder.Property(x => x.SellPrice).IsRequired(true);
    }
}