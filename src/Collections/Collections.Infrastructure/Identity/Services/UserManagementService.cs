using Collections.Infrastructure.Identity.Models;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Identity.Services;

public class UserManagementService : IUserManagementService<ApplicationUser>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserManagementService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public IQueryable<ApplicationUser> ListAllUsersPaginated(int skip = 0, int take = int.MaxValue)
    {
        return _userManager.Users
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .Skip(skip)
            .Take(take);
    }

    public async Task BlockUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.SetLockoutEndDateAsync(user, DateTime.UtcNow.AddYears(100));
        await _userManager.UpdateSecurityStampAsync(user);
    }
    
    public async Task UnlockUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.SetLockoutEndDateAsync(user, null);
        await _userManager.UpdateSecurityStampAsync(user);
    }

    public async Task DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.DeleteAsync(user);
    }

    public async Task MakeAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.AddToRoleAsync(user, UserRoleConstants.AdminRole);
    }

    public async Task RemoveAdmin(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        await _userManager.RemoveFromRoleAsync(user, UserRoleConstants.AdminRole);
    }
}
