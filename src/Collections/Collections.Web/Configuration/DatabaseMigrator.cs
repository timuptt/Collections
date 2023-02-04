using Collections.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Configuration;

public static class DatabaseMigrator
{
    public static async Task MigrateDatabaseAsync(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<CollectionsDbContext>();
        await context.Database.MigrateAsync();
    }
}