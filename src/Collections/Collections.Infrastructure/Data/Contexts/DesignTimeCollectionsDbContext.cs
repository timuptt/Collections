using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Collections.Infrastructure.Data.Contexts;

public class DesignTimeCollectionsDbContext : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder() as IConfigurationBuilder;
        configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "Configuration/appsettings.json"));
        var configuration = configurationBuilder.Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseNpgsql(connectionString);
        return new (builder.Options);
    }
}