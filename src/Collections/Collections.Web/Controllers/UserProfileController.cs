using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Constants.Filtering;
using Collections.Shared.Interfaces;
using Collections.Web.Filters;
using Collections.Web.Models;
using Collections.Web.Models.UserProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

[Authorize]
public class UserProfileController : Controller
{
    private readonly IReadRepository<UserProfile> _userProfileReadRepository;

    public UserProfileController(IReadRepository<UserProfile> userProfileReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var profileSpec = new UserProfileByIdSpec(id);
        var profileViewModel = await _userProfileReadRepository.GetBySpecProjectedAsync<UserProfileViewModel>(profileSpec);
        return View(profileViewModel);
    }
}