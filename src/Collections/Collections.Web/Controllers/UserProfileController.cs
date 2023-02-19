using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models;
using Collections.Web.Models.UserProfile;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

public class UserProfileController : Controller
{
    private readonly IReadRepository<UserProfile> _userProfileReadRepository;
    private readonly IReadRepository<UserCollection> _userCollectionsReadRepository;

    public UserProfileController(IReadRepository<UserProfile> userProfileReadRepository, IReadRepository<UserCollection> userCollectionsReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
        _userCollectionsReadRepository = userCollectionsReadRepository;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Profile(int id, int pageNumber = 1, int pageSize = 10)
    {
        var profileSpec = new UserProfileByIdSpec(id);
        var profileViewModel = await _userProfileReadRepository.GetBySpecProjectedAsync<UserProfileViewModel>(profileSpec);
        var collectionsSpec = new UserCollectionsByProfileIdFilteredPaginatedSpec(id, pageSize, pageNumber - 1);
        var countSpec = new UserCollectionsCountByProfileIdSpec(id);
        profileViewModel.UserCollections =
            await PaginatedList<CollectionForUserProfileViewModel, UserCollection>.CreateAsync(_userCollectionsReadRepository,
                collectionsSpec, countSpec, pageNumber, pageSize);
        return View(profileViewModel);
    }
}