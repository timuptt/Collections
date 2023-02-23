using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;
using Collections.Web.Models.UserProfile;

namespace Collections.Web.Models.Collection.Items;

public class ItemExtendedViewModel : IMapWith<Item>
{
    public string Id { get; set; }
    
    public string Title { get; set; }
    
    public int UserCollectionId { get; set; }
    
    public int UserProfileId { get; set; }
    
    public string UserCollectionTitle { get; set; }
    
    public string LikesCount { get; set; }
    
    public IEnumerable<ExtraFieldViewModel> ExtraFields { get; set; }
    
    public IEnumerable<TagViewModel> Tags { get; set; }
    
    public DateTime AddedOn { get; set; }
    
    public DateTime ModifiedOn { get; set; }
    
    public IEnumerable<CommentViewModel> Comments { get; set; }
    
    public IEnumerable<LikeViewModel> Likes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, ItemExtendedViewModel>()
            .ForMember(itemVm => itemVm.LikesCount,
                opt => opt.MapFrom(item => item.Likes.Count))
            .ForMember(itemVm => itemVm.UserCollectionTitle,
                opt => opt.MapFrom(item => item.UserCollection.Title))
            .ForMember(itemVm => itemVm.Comments, opt =>
                opt.MapFrom(item => item.Comments.OrderByDescending(c => c.AddedOn)))
            .ForMember(itemVm => itemVm.UserProfileId, opt => 
                opt.MapFrom(item => item.UserCollection.UserProfileId));
    }
}