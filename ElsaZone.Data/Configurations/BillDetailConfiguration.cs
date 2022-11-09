using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class BillDetailConfiguration:IEntityTypeConfiguration<BillDetail>
{
    public void Configure(EntityTypeBuilder<BillDetail> builder)
    {
        builder.ToTable("BillDetails");

        builder.HasKey(x => x.BillDetailId);
        builder.Property(x => x.BillDetailId).UseIdentityColumn();
        builder.Property(x => x.BillId).IsRequired(true);
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.Quantity).IsRequired(true);
        builder.Property(x => x.SellPrice).IsRequired(true);
       
    }
}