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
        builder.Property(x => x.BillCode).IsRequired(true).HasMaxLength(30).IsUnicode(false);
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(100).IsUnicode(true);
        builder.Property(x => x.Address).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Ward).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.District).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Province).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Email).HasMaxLength(100).IsUnicode(false);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsUnicode(false);
        builder.Property(x => x.DeliveredStatus).HasDefaultValue(DeliveredStatus.Waiting);
        builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValueSql("getdate()");
        builder.Property(x => x.Note).IsRequired(false).IsUnicode().HasMaxLength(200);
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(IsDeleted.Normal);
        builder.HasOne(x=>x.AppUser).WithMany(x=>x.Bills).HasForeignKey(x => x.UserName);
    }
}