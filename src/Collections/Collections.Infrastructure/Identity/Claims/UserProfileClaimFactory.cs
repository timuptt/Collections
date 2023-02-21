using System.Security.Claims;
using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Collections.Infrastructure.Identity.Claims;

public class UserProfileClaimFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IReadRepository<UserProfile> _readRepository;

    public UserProfileClaimFactory(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
        IOptions<IdentityOptions> options, IReadRepository<UserProfile> readRepository) : base(userManager, roleManager, options)
    {
        _readRepository = readRepository;
    }

    protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser applicationUser)
    {
        var identity = await base.GenerateClaimsAsync(applicationUser);
        var userProfile = await _readRepository.GetByIdAsync(applicationUser.UserProfileId);
        identity.AddClaim(new Claim(UserClaimsConstants.UserProfileIdClaim, applicationUser.UserProfileId.ToString()));
        identity.AddClaim(new Claim(UserClaimsConstants.UserProfileFullnameClaim, string.Join(" ", userProfile.FirstName, userProfile.LastName)));
        return identity;
    }
}