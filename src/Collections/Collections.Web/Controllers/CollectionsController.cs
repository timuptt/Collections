using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

[Authorize]
public class CollectionsController : Controller
{
    private readonly ICollectionService _collectionService;
    private readonly ICollectionViewModelService _collectionViewModelService;
    private readonly IThemeViewModelService _themeViewModelService;
    private readonly IReadRepository<UserCollection> _userCollectionReadRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public CollectionsController(ICollectionService collectionService, IThemeViewModelService themeViewModelService,
        UserManager<ApplicationUser> userManager, ICollectionViewModelService collectionViewModelService,
        IReadRepository<UserCollection> userCollectionReadRepository, IMapper mapper)
    {
        _collectionService = collectionService;
        _themeViewModelService = themeViewModelService;
        _userManager = userManager;
        _collectionViewModelService = collectionViewModelService;
        _userCollectionReadRepository = userCollectionReadRepository;
        _mapper = mapper;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create()
    {
        var createCollectionViewModel = new CreateCollectionViewModel
        {
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
            int.Parse(User.Claims.First(c => c.Type == UserClaimsConstants.UserProfileIdClaim).Value),
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