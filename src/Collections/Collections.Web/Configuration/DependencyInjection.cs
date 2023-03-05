using System.Globalization;
using System.Reflection;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Services;
using Collections.Infrastructure.Data.Contexts;
using Collections.Infrastructure.Data.Repositories;
using Collections.Infrastructure.Data.Repositories.Options;
using Collections.Infrastructure.FileStorage.Configuration;
using Collections.Infrastructure.FileStorage.Services;
using Collections.Infrastructure.Identity.Claims;
using Collections.Infrastructure.Identity.Models;
using Collections.Infrastructure.Identity.Services;
using Collections.Shared.Interfaces;
using Collections.Web.Common.Mappings;
using Collections.Web.Configuration.Options;
using Collections.Web.Filters;
using Collections.Web.Interfaces;
using Collections.Web.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ILikesService, LikesService>();
        return services;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(EfRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(CachedRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IItemSearchRepository, ItemSearchRepository>();
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.Configure<GoogleCloudOptions>(configuration);
        services.AddScoped<ICloudStorageService, CloudStorageService>();
        return services;
    }

    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, UserProfileClaimFactory>();
        services.AddScoped<IUserManagementService<ApplicationUser>, UserManagementService>();
        services.AddDataProtection()
            .PersistKeysToDbContext<ApplicationDbContext>();
        services.AddAuthentication()
            .AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            })
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
            })
            .AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
            });
        return services;
    }

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {

        services.AddLocalization(options =>
        {
            options.ResourcesPath = "Resources";
        });
        services.AddControllersWithViews()
            .AddRazorRuntimeCompilation()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options => {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedResources));
            });
        return services;
    }

    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddScoped<IThemeViewModelService, ThemeViewModelService>();
        services.AddScoped<IHomePageViewModelService, HomePageViewModelService>();
        services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                configuration.AddProfile(new AssemblyMappingProfile(Assembly.GetAssembly(typeof(IMapWith<>))!));
            });
        services.AddScoped<IFilter<UserCollection>, CollectionFilter>();
        services.AddScoped<IFilter<Item>, ItemFilter>();
        services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
        services.AddScoped<ILocalisationOptionsProvider, LocalizationOptionsProvider>();
        services.AddSignalR();
        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<CachingOptions>(configuration);
        services.Configure<SiteOptions>(configuration);
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("ru"),
            };
            options.DefaultRequestCulture = new RequestCulture("en");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        services.Configure<SecurityStampValidatorOptions>(o =>
            o.ValidationInterval =
                TimeSpan.FromSeconds(int.TryParse(configuration["SecurityStampValidationInterval"], out var value)
                    ? value
                    : 0));
        return services;
    }
}