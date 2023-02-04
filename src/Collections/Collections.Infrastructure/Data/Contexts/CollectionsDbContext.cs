using Collections.Infrastructure.Data.Extensions;
using Collections.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Data.Contexts;

public class CollectionsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public CollectionsDbContext(DbContextOptions<CollectionsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.SeedUserRoles();
    }
}