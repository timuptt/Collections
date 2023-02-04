using Collections.Infrastructure.Data.Contexts;
using Collections.Infrastructure.Identity.Models;
using Collections.Web.Configuration.Connection;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CollectionsDbContext>(options => 
            options.UseNpgsql(DbConnectionHelper.GetConnectionString(configuration)));
        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<CollectionsDbContext>();
        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();
        return services;
    }
}