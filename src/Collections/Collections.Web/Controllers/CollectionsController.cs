using System.Runtime.InteropServices.JavaScript;
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
    private readonly IThemeViewModelService _themeViewModelService;
    private readonly IReadRepository<UserCollection> _userCollectionReadRepository;
    private readonly ICurrentUserProvider _currentUser;
    private readonly ICloudStorageService _cloudStorageService;
    private readonly IDataExportService _dataExportService;
    private readonly IMapper _mapper;

    public CollectionsController(ICollectionService collectionService, 
        IThemeViewModelService themeViewModelService,
        IReadRepository<UserCollection> userCollectionReadRepository, 
        IMapper mapper, 
        ICurrentUserProvider currentUser,
        ICloudStorageService cloudStorageService, IDataExportService dataExportService)
    {
        _collectionService = collectionService;
        _themeViewModelService = themeViewModelService;
        _userCollectionReadRepository = userCollectionReadRepository;
        _mapper = mapper;
        _currentUser = currentUser;
        _cloudStorageService = cloudStorageService;
        _dataExportService = dataExportService;
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
            UserProfileId = _currentUser.ProfileId,
            Themes = await _themeViewModelService.GetThemesAsSelectList()
        };
        return View(createCollectionViewModel);
    }
    
    [Authorize(Roles = UserRoleConstants.AdminRole)]
    public async Task<IActionResult> CreateAsUser(int profileId)
    {
        var createCollectionViewModel = new CreateCollectionViewModel
        {
            UserProfileId = profileId,
            Themes = await _themeViewModelService.GetThemesAsSelectList()
        };
        return View("Create", createCollectionViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCollectionViewModel request)
    {
        if (!ModelState.IsValid)
        {
            request.Themes = await _themeViewModelService.GetThemesAsSelectList();
            return View(request);
        }
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
        collectionVm.Themes = await _themeViewModelService.GetThemesAsSelectList();
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
        var specification = new UserCollectionWithItemsByIdSpec(id);
        var collectionVm = await _userCollectionReadRepository.GetBySpecProjectedAsync<CollectionWithItemsViewModel>(specification);
        return View(collectionVm);
    }

    [AllowAnonymous]
    public async Task<IActionResult> ExportAsCsv(int id)
    {
        var file = await _dataExportService.ExportCollectionToCsv(id);
        return File(file.ToArray(), "text/csv", $"Collection_{id}_{DateTime.Now.Ticks}.csv");
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