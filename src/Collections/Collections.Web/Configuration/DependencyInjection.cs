using System.Reflection;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Services;
using Collections.Infrastructure.Data.Contexts;
using Collections.Infrastructure.Data.Repositories;
using Collections.Infrastructure.Identity.Claims;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Interfaces;
using Collections.Web.Common.Mappings;
using Collections.Web.Configuration.Connection;
using Collections.Web.Filters;
using Collections.Web.Interfaces;
using Collections.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ILikesService, LikesService>();
        return services;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(DbConnectionHelper.GetConnectionString(configuration)));
        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserProfileClaimFactory>();
        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddRazorRuntimeCompilation();
        return services;
    }

    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<ICollectionViewModelService, CollectionViewModelService>();
        services.AddScoped<IThemeViewModelService, ThemeViewModelService>();
        services.AddScoped<IHomePageViewModelService, HomePageViewModelService>();
        services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetAssembly(typeof(IMapWith<>))));
            }
                );
        services.AddScoped<IFilter<UserCollection>, CollectionFilter>();
        services.AddSignalR();
        return services;
    }
}