using ElsaZone.Data.Entities;
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
        builder.Property(x => x.BillCode).IsRequired(true);
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Address).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Ward).IsRequired(true);
        builder.Property(x => x.District).IsRequired(true);
        builder.Property(x => x.Province).IsRequired(true);
    }
}