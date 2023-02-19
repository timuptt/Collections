using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class CommentViewModel : IMapWith<Comment>
{
    public int Id { get; set; }
    
    public string UserProfileId { get; set; }
    
    public string UserName { get; set; }
    
    public string Body { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Comment, CommentViewModel>()
            .ForMember(commentVm => commentVm.UserName,
                opt => opt.MapFrom(
                    item => string.Join(" ", item.UserProfile.FirstName, item.UserProfile.LastName)));
    }
}