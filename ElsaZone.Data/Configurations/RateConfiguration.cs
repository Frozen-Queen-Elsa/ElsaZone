using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class RateConfiguration:IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("Rates");

        builder.HasKey(x => x.RateId);
        builder.Property(x => x.RateId).UseIdentityColumn();
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.AccountId).IsRequired(true);
      
    }
}