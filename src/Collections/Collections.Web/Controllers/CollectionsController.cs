using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

[Authorize]
public class CollectionsController : Controller
{
    private readonly ICollectionService _collectionService;
    private readonly ICollectionViewModelService _collectionViewModelService;
    private readonly IThemeViewModelService _themeViewModelService;
    private readonly IReadRepository<UserCollection> _userCollectionReadRepository;
    private readonly ICurrentUserProvider _currentUser;
    private readonly IMapper _mapper;

    public CollectionsController(ICollectionService collectionService, IThemeViewModelService themeViewModelService,
        ICollectionViewModelService collectionViewModelService,
        IReadRepository<UserCollection> userCollectionReadRepository, IMapper mapper, ICurrentUserProvider currentUser)
    {
        _collectionService = collectionService;
        _themeViewModelService = themeViewModelService;
        _collectionViewModelService = collectionViewModelService;
        _userCollectionReadRepository = userCollectionReadRepository;
        _mapper = mapper;
        _currentUser = currentUser;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create(int profileId)
    {
        if (profileId <= 0)
        {
            profileId = _currentUser.ProfileId;
        }
        var createCollectionViewModel = new CreateCollectionViewModel
        {
            UserProfileId = profileId,
            Themes = await _themeViewModelService.GetThemesAsSelectList()
        };
        return View(createCollectionViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollectionViewModel request)
    {
        if (!ModelState.IsValid)
        {
            request.Themes = await _themeViewModelService.GetThemesAsSelectList();
            return View(request);
        }
        var extraFieldValueTypes = new List<ExtraFieldValueType>();
        if (request.ExtraFieldValueTypes != null)
        {
            extraFieldValueTypes = request.ExtraFieldValueTypes.Select(e => new ExtraFieldValueType()
            {
                Name = e.Name,
                IsRequired = e.IsRequired,
                IsVisible = e.IsVisible,
                ValueType = e.ValueType
            }).ToList();
        }
        await _collectionService.CreateCollection(
            request.UserProfileId,
            request.SelectedThemeId, request.Title, request.Description,
            request.ImageSource, extraFieldValueTypes);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Update(int collectionId)
    {
        var specification = new UserCollectionByIdSpec(collectionId);
        var collectionVm =
           await _userCollectionReadRepository.GetBySpecProjectedAsync<UpdateCollectionViewModel>(specification);
        return View(collectionVm);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCollectionViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return View(request);
        }
        await _collectionService.UpdateCollection(_mapper.Map<UpdateUserCollectionDto>(request));
        return RedirectToAction("Details", "Collections", request.Id);
    }
    
    public async Task<IActionResult> Delete(int collectionId)
    {
        await _collectionService.DeleteCollection(collectionId);
        return RedirectToAction("Index", "Home");
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var collectionVm = await _collectionViewModelService.GetCollectionViewModelById(id);
        return View(collectionVm);
    }

    public IActionResult CreateItem(int collectionId)
    {
        var itemVm = new CreateItemViewModel() { UserCollectionId = collectionId };
        return RedirectToAction("Create", "Item", itemVm);
    }
}