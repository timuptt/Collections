using Collections.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Host;

public class HostedDbMigrationService : IHostedService
{
    private readonly ApplicationDbContext _dbContext;

    public HostedDbMigrationService(ApplicationDbContext context)
    {
        _dbContext = context;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _dbContext.Database.MigrateAsync(cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}