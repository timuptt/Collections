using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Identity.Models;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
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
    private readonly UserManager<ApplicationUser> _userManager;

    public CollectionsController(ICollectionService collectionService, IThemeViewModelService themeViewModelService,
        UserManager<ApplicationUser> userManager, ICollectionViewModelService collectionViewModelService)
    {
        _collectionService = collectionService;
        _themeViewModelService = themeViewModelService;
        _userManager = userManager;
        _collectionViewModelService = collectionViewModelService;
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
        var user = await _userManager.GetUserAsync(User);
        await _collectionService.CreateCollection(user.UserProfileId, request.SelectedThemeId, request.Title, request.Description,
            request.ImageSource, new List<ExtraFieldValueType>());
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Collection(int id)
    {
        var collectionVm = await _collectionViewModelService.GetCollectionViewModelById(id);
        return View(collectionVm);
    }
}