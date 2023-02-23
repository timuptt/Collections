using Microsoft.AspNetCore.Identity;

namespace Collections.Infrastructure.Identity.Models;

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}