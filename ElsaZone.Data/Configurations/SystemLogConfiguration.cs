using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class SystemLogConfiguration:IEntityTypeConfiguration<SystemLog>
{
    public void Configure(EntityTypeBuilder<SystemLog> builder)
    {
        builder.ToTable("SystemLogs");

        builder.HasKey(x => x.LogId);
        builder.Property(x => x.LogId).UseIdentityColumn();
        builder.Property(x => x.AdminId).IsRequired(true);
        builder.Property(x => x.LogDescription).IsRequired(true);
      
    }
}