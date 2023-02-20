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
    private readonly IReadRepository<UserCollection> _userCollectionsReadRepository;
    private readonly IFilter<UserCollection> _filter = new CollectionFilter();

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

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id, int pageNumber = 1, int pageSize = 10, 
        string sortProp = "", OrderEnum sortOrder = OrderEnum.Ascending, string searchProp = "Title", string searchTerm = "")
    {
        var profileSpec = new UserProfileByIdSpec(id);
        var profileViewModel = await _userProfileReadRepository.GetBySpecProjectedAsync<UserProfileViewModel>(profileSpec);
        var collectionsSpec = new UserCollectionsByProfileIdFilteredPaginatedSpec(id, pageSize, pageNumber - 1, 
            _filter.GetSearchPredicate(searchProp), _filter.GetOrderPredicate(sortProp), searchTerm, _filter.GetSortOrder(sortOrder));
        var countSpec = new UserCollectionsCountByProfileIdSpec(id);
        profileViewModel.UserCollections =
            await PaginatedList<CollectionForUserProfileViewModel, UserCollection>.CreateAsync(_userCollectionsReadRepository,
                collectionsSpec, countSpec, pageNumber, pageSize);
        return View(profileViewModel);
    }
}