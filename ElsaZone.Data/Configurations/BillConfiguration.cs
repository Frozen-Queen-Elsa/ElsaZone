using ElsaZone.Data.Entities;
using ElsaZone.Data.Enums.Common;
using ElsaZone.Data.Enums.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class BillConfiguration:IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> builder)
    {
        builder.ToTable("Bills");

        builder.HasKey(x => x.BillId);
        builder.Property(x => x.BillId).UseIdentityColumn();
        builder.Property(x => x.BillCode).IsRequired(true).HasMaxLength(30).HasColumnType("varchar(30)");
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100).HasColumnType("nvarchar(100)");
        builder.Property(x => x.Address).IsRequired(true).HasMaxLength(50).HasColumnType("nvarchar(50)");
        builder.Property(x => x.Ward).IsRequired(true).HasMaxLength(50).HasColumnType("nvarchar(50)");
        builder.Property(x => x.District).IsRequired(true).HasMaxLength(50).HasColumnType("nvarchar(50)");
        builder.Property(x => x.Province).IsRequired(true).HasMaxLength(50).HasColumnType("nvarchar(50)");
        builder.Property(x => x.Email).HasMaxLength(100).HasColumnType("varchar(100)");
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).HasColumnType("varchar(20)");
        builder.Property(x => x.DeliveredStatus).HasDefaultValue(DeliveredStatus.Waiting);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);

        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
    }
}