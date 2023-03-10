using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Items;

public class CardItemViewModel : IMapWith<Item>
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int LikesCount { get; set; }
    
    public int CommentsCount { get; set; }

    public DateTime AddedOn { get; set; }
    
    public IEnumerable<TagViewModel> Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, CardItemViewModel>()
            .ForMember(itemVm => itemVm.LikesCount,
                opt => opt.MapFrom(i => i.Likes.Count))
            .ForMember(itemVm => itemVm.CommentsCount,
                opt => opt.MapFrom(i => i.Comments.Count));
    }
}