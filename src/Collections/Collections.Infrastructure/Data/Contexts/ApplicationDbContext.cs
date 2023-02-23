using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Data.Extensions;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Data.Contexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, 
    ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public DbSet<UserCollection> UserCollections { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ExtraFieldValueType> ExtraFieldValueTypes { get; set; }
    public DbSet<ExtraField> ExtraFields { get; set; }
    public DbSet<UserCollectionTheme> UserCollectionThemes { get; set; } 
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Like> Likes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.SeedUserRoles();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var utcNow = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.AddedOn = utcNow;
                    entry.Entity.ModifiedOn = utcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifiedOn = utcNow;
                    break;
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}