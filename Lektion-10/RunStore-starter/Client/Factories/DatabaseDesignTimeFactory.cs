using System;
using System.Reflection;
using Client.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Client.Factories;

public class DatabaseDesignTimeFactory : IDesignTimeDbContextFactory<RunStoreDbContext>
{
    public RunStoreDbContext CreateDbContext(string[] args)
    {
        var host = Host.CreateApplicationBuilder();
        host.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly());

        var connectionString = host.Configuration.GetConnectionString("pgsql");

        var builder = new DbContextOptionsBuilder<RunStoreDbContext>();
        builder.UseNpgsql(connectionString);

        return new RunStoreDbContext(builder.Options);
    }
}
