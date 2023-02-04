using Microsoft.AspNetCore.Identity;

namespace Collections.Infrastructure.Identity.Models;

public sealed class ApplicationRole : IdentityRole
{
    public ApplicationRole(string name)
        : base(name)
    {
        NormalizedName = name.ToUpperInvariant();
    }
}