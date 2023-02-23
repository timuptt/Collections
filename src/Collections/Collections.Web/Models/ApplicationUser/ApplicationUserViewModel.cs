using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.Infrastructure.Identity.Models;

namespace Collections.Web.Models.ApplicationUser;

public class ApplicationUserViewModel : IMapWith<Infrastructure.Identity.Models.ApplicationUser>
{
    public string Id { get; set; }
    
    public int UserProfileId { get; set; }
    public string FullName { get; set; }

    public IEnumerable<ApplicationUserRole> UserRoles { get; set; }
    
    public UserStatuses Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Infrastructure.Identity.Models.ApplicationUser, ApplicationUserViewModel>()
            .ForMember(a => a.FullName, opt =>
                opt.MapFrom(u => string.Join(" ", u.UserProfile.FirstName, u.UserProfile.LastName)))
            .ForMember(a => a.Status, opt =>
                opt.MapFrom(u => u.LockoutEnd == null ? UserStatuses.Active : UserStatuses.Blocked));
    }
}