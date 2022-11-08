using ElsaZone.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
namespace ElsaZone.Data.Configurations;

public class ContactConfiguration:IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");

        builder.HasKey(x => x.ContactId);
        builder.Property(x => x.ContactId).UseIdentityColumn();
        builder.Property(x => x.Name).IsRequired(true);
        builder.Property(x => x.Message).IsRequired(true);
        

       
    }
}