using Collections.Shared.Constants.Identity;
using Collections.Web.Interfaces;

namespace Collections.Web.Services;

public class CurrentUserProvider : ICurrentUserProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int ProfileId =>
        int.Parse(_httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c =>
            c.Type == UserClaimsConstants.UserProfileIdClaim)!.Value);
    
    public string FullName => 
        _httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(c =>
            c.Type == UserClaimsConstants.UserProfileFullnameClaim)!.Value;

    public bool IsAdmin =>
        _httpContextAccessor.HttpContext!.User.IsInRole(UserRoleConstants.AdminRole);

    public bool HasPermissions(int profileId) => 
        _httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated && (IsAdmin || ProfileId == profileId);
}