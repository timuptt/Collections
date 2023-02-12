using System.Diagnostics;
using Collections.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Collections.Web.Models;

namespace Collections.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomePageViewModelService _homePageViewModelService;

    public HomeController(ILogger<HomeController> logger, IHomePageViewModelService homePageViewModelService)
    {
        _logger = logger;
        _homePageViewModelService = homePageViewModelService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _homePageViewModelService.GetHomePageViewModel());
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Create() => RedirectToAction("Create", "Collections");
}