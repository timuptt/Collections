using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Collections.Web.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Collections.Web.Controllers;

[Authorize(Roles = UserRoleConstants.AdminRole)]
public class AdminController : Controller
{
    private readonly IUserManagementService<ApplicationUser> _managementService;
    private readonly IMapper _mapper;

    public AdminController(IUserManagementService<ApplicationUser> managementService, IMapper mapper)
    {
        _managementService = managementService;
        _mapper = mapper;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var viewModel = 
           await _managementService.ListAllUsersPaginated().ProjectTo<ApplicationUserViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        return View(viewModel);
    }

    public async Task<IActionResult> BlockUser(string userId)
    {
        await _managementService.BlockUser(userId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> MakeAdmin(string userId)
    {
        await _managementService.MakeAdmin(userId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveAdmin(string userId)
    {
        await _managementService.RemoveAdmin(userId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UnlockUser(string userId)
    {
        await _managementService.UnlockUser(userId);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> DeleteUser(string userId)
    {
        await _managementService.DeleteUser(userId);
        return RedirectToAction("Index");
    }
}