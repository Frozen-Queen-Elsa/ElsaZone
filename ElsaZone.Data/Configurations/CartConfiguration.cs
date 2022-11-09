using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class CartConfiguration:IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable("Carts");

        builder.HasKey(x => x.CartId);
        builder.Property(x => x.CartId).UseIdentityColumn();
        builder.Property(x => x.AccountId).IsRequired(true);
        builder.Property(x => x.ProductId).IsRequired(true);
        

       
    }
}