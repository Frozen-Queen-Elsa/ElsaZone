using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class PromoteConfiguration:IEntityTypeConfiguration<Promote>
{
    public void Configure(EntityTypeBuilder<Promote> builder)
    {
        builder.ToTable("Promotes");

        builder.HasKey(x => x.PromoteId);
        builder.Property(x => x.PromoteId).UseIdentityColumn();
        builder.Property(x => x.DiscountType).IsRequired(true);
        builder.Property(x => x.DiscountValue).IsRequired(true);
      
    }
}