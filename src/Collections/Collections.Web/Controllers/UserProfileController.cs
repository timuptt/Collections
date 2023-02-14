using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

public class UserProfileController : Controller
{
    private readonly IReadRepository<UserProfile> _userProfileReadRepository;

    public UserProfileController(IReadRepository<UserProfile> userProfileReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Profile(int id)
    {
        var specification = new UserProfileByIdSpec(id);
        var profileViewModel = await _userProfileReadRepository.GetBySpecProjectedAsync<UserProfileViewModel>(specification);
        return View(profileViewModel);
    }
}