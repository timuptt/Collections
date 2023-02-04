using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Data.Extensions;

public static class ModelBuilderExtenstion
{
    public static ModelBuilder SeedUserRoles(this ModelBuilder builder)
    {
        var roles = new List<ApplicationRole>
            { new(UserRoleConstants.ApplicationUserRole), new(UserRoleConstants.AdminRole), new(UserRoleConstants.AuthorRole) };
        builder.Entity<ApplicationRole>().HasData(roles);
        return builder;
    }
}