using System.Net;
using Collections.Web.Configuration;
using Collections.Web.Hubs;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.
builder.Services
    .ConfigureServices(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddIdentity(builder.Configuration)
    .AddPresentation()
    .AddApplication()
    .AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

await app.MigrateDatabaseAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseRequestLocalization();

app.MapRazorPages();

app.MapHub<CommentsHub>("/commentsHub");

app.Run();