using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.UserProfile;

public class UserProfileViewModel : IMapWith<ApplicationCore.Models.UserProfile>
{
    public int Id { get; set; }
    
    public string ApplicationUserId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public PaginatedList<CollectionForUserProfileViewModel, UserCollection> UserCollections { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApplicationCore.Models.UserProfile, UserProfileViewModel>()
            .ForMember(p => p.UserCollections, opt => opt.Ignore());
    }
}