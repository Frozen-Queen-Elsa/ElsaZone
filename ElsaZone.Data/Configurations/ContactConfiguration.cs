using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ElsaZone.Data.Enums.Contact;

namespace ElsaZone.Data.Configurations;

public class ContactConfiguration:IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");

        builder.HasKey(x => x.ContactId);
        builder.Property(x => x.ContactId).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired(true).HasMaxLength(50).IsUnicode(true);
        builder.Property(x => x.Email).IsRequired(false).IsUnicode(false).HasMaxLength(100);
        builder.Property(x => x.Message).IsRequired(true).HasColumnType("ntext");
        builder.Property(x => x.ReadStatus).IsRequired().HasDefaultValue(ReadStatus.Unread);
        builder.Property(x => x.PhoneNumber).HasMaxLength(20).IsUnicode(false).IsRequired(false);

    }
}