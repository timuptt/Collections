using System.Security.Claims;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Collections.Infrastructure.Identity.Claims;

public class UserProfileClaimFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileClaimFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IOptions<IdentityOptions> options) : base(userManager, roleManager, options)
    {
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser applicationUser)
    {
        var identity = await base.GenerateClaimsAsync(applicationUser);
        identity.AddClaim(new Claim(UserClaimsConstants.UserProfileIdClaim, applicationUser.UserProfileId.ToString()));
        return identity;
    }
}