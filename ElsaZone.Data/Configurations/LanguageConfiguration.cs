using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ElsaZone.Data.Enums.Common;

namespace ElsaZone.Data.Configurations;

public class LanguageConfiguration:IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable("Languages");

        builder.HasKey(x => x.LanguageId);
        builder.Property(x => x.LanguageId).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.IsDefault).HasDefaultValue(IsDefault.Normal);




    }
}