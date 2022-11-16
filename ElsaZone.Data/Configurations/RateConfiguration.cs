using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Configurations;

public class RateConfiguration:IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("Rates");

        builder.HasKey(x => x.RateId);
        builder.Property(x => x.RateId).UseIdentityColumn();
        builder.Property(x => x.ProductId).IsRequired(true);

        builder.Property(x => x.Comment).HasMaxLength(255).IsUnicode(true).IsRequired(false);
        builder.Property(x => x.Description).HasMaxLength(100).IsUnicode(true).IsRequired(false);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");

        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
        builder.HasOne(x => x.Product).WithMany(x => x.Rates).HasForeignKey(x => x.ProductId);
        builder.HasOne(x => x.AppUser).WithMany(x => x.Rates).HasForeignKey(x => x.UserName);
        
    }
}