using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;
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
    private readonly ICloudStorageService _cloudStorageService;
    private readonly IMapper _mapper;

    public CollectionsController(ICollectionService collectionService, IThemeViewModelService themeViewModelService,
        ICollectionViewModelService collectionViewModelService,
        IReadRepository<UserCollection> userCollectionReadRepository, IMapper mapper, ICurrentUserProvider currentUser,
        ICloudStorageService cloudStorageService)
    {
        _collectionService = collectionService;
        _themeViewModelService = themeViewModelService;
        _collectionViewModelService = collectionViewModelService;
        _userCollectionReadRepository = userCollectionReadRepository;
        _mapper = mapper;
        _currentUser = currentUser;
        _cloudStorageService = cloudStorageService;
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
        // var extraFieldValueTypes = new List<ExtraFieldValueType>();
        // if (request.ExtraFieldValueTypes != null)
        // {
        //     extraFieldValueTypes = request.ExtraFieldValueTypes.Select(e => new ExtraFieldValueType()
        //     {
        //         Name = e.Name,
        //         IsRequired = e.IsRequired,
        //         IsVisible = e.IsVisible,
        //         ValueType = e.ValueType
        //     }).ToList();
        // }
        if (request.Image != null)
        {
            (request.ImageSource, request.ImageName) = await _cloudStorageService.UploadImageAsync(request.Image);
        }
        await _collectionService.CreateCollection(_mapper.Map<CreateUserCollectionDto>(request));
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
        if (!ModelState.IsValid) return View(request);
        if (ImageIsChanged(request))
        {
            if(PreviousImageExist(request))
                await _cloudStorageService.DeleteFileAsync(request.ImageName!);
            (request.ImageSource, request.ImageName) = await _cloudStorageService.UploadImageAsync(request.Image!);
        }
        await _collectionService.UpdateCollection(_mapper.Map<UpdateUserCollectionDto>(request));
        return RedirectToAction("Details", "Collections",new {id = request.Id});
    }

    public async Task<IActionResult> Delete(int collectionId, string? imageName)
    {
        await _collectionService.DeleteCollection(collectionId);
        if (imageName != null) await _cloudStorageService.DeleteFileAsync(imageName);
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
    
    private static bool ImageIsChanged(UpdateCollectionViewModel request) =>
        request.Image != null;

    private static bool PreviousImageExist(UpdateCollectionViewModel request) =>
        !string.IsNullOrEmpty(request.ImageName) && !string.IsNullOrEmpty(request.ImageSource);
}