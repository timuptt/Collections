using Microsoft.AspNetCore.Identity;

namespace Collections.Infrastructure.Identity.Models;

public sealed class ApplicationRole : IdentityRole
{
    public ICollection<ApplicationUserRole> UserRoles { get; set; }
    
    public ApplicationRole(string name)
        : base(name)
    {
        NormalizedName = name.ToUpperInvariant();
    }
}