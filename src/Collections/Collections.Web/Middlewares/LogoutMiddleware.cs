using System.Security.Claims;
using Collections.Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Collections.Web.Middlewares;

public class LogoutMiddleware
{
    private readonly RequestDelegate _next;

    public LogoutMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            var userId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByIdAsync(userId);
            if (user is not { LockoutEnd: null })
            {
                await signInManager.SignOutAsync();
                context.Response.Redirect("/Identity/Account/Login");
                return;
            }
        }
        await _next(context);
    }
}