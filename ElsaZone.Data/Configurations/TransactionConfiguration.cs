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
        builder.Property(x => x.TransactionDate).HasDefaultValueSql("getdate()");
        builder.Property(x => x.Message).IsRequired(false).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.Provider).IsRequired(false).HasMaxLength(50).HasColumnType("nvarchar(50)");
        builder.Property(x => x.Result).IsRequired();
        builder.Property(x => x.ExternalTransactionId).IsRequired(false);
    }
}