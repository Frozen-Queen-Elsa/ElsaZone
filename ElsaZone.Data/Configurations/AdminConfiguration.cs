using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ElsaZone.Data.Configurations;

public class AdminConfiguration:IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.HasKey(x => x.AdminId);
        builder.Property(x => x.AdminId).UseIdentityColumn();
        builder.Property(x => x.Password).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Username).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.Phone).HasMaxLength(15);
    }
}