using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(x => x.TransactionId);
        builder.Property(x => x.TransactionId).UseIdentityColumn();
        builder.Property(x => x.TransactionDate).HasDefaultValue(DateTime.Now);
        builder.Property(x => x.Message).HasMaxLength(100).HasColumnType("nvarchar(100)");
        builder.Property(x => x.Provider).HasMaxLength(50).HasColumnType("nvarchar(50)");
    }
}