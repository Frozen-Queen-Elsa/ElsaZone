using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace ElsaZone.Data.EF;

public class ElsaZoneDbContextFactory:IDesignTimeDbContextFactory<ElsaZoneDbContext>
{
    public ElsaZoneDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ElsaZoneDb");

        var optionsBuilder = new DbContextOptionsBuilder<ElsaZoneDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ElsaZoneDbContext(optionsBuilder.Options);
    }
}