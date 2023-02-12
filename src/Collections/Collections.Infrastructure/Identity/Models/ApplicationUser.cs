using Collections.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity;

namespace Collections.Infrastructure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public int UserProfileId { get; set; }
    
    public UserProfile UserProfile { get; set; }
}