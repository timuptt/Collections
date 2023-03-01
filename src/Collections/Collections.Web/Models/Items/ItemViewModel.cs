using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.ExtraFields;

namespace Collections.Web.Models.Items;

public class ItemViewModel : IMapWith<Item>
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [DisplayName("Likes")]
    public int LikesCount { get; set; }
    
    [DisplayName("Comments")]
    public int CommentsCount { get; set; }
    
    [DisplayName("Collection")]
    public string UserCollectionName { get; set; }
    public IEnumerable<ExtraFieldViewModel> ExtraFields { get; set; }
    
    [DisplayName("Tags")]
    public IEnumerable<TagViewModel> Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, ItemViewModel>()
            .ForMember(itemVm => itemVm.LikesCount,
                opt => opt.MapFrom(item => item.Likes.Count))
            .ForMember(itemVm => itemVm.CommentsCount,
            opt => opt.MapFrom(item => item.Comments.Count))
            .ForMember(itemVm => itemVm.UserCollectionName, opt =>
                opt.MapFrom(item => item.UserCollection.Title));
    }
}