using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class ItemViewModel : IMapWith<Item>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public int LikesCount { get; set; }
    
    public IEnumerable<ExtraFieldViewModel> ExtraFields { get; set; }
    
    public IEnumerable<TagViewModel> Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, ItemViewModel>()
            .ForMember(itemVm => itemVm.LikesCount,
                opt => opt.MapFrom(item => item.Likes.Count));
    }
}