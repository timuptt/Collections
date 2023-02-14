using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class ItemViewModel : IMapWith<Item>
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [DisplayName("Likes")]
    public int LikesCount { get; set; }
    
    public IEnumerable<ExtraFieldViewModel> ExtraFields { get; set; }
    
    [DisplayName("Tags")]
    public IEnumerable<TagViewModel> Tags { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, ItemViewModel>()
            .ForMember(itemVm => itemVm.LikesCount,
                opt => opt.MapFrom(item => item.Likes.Count));
    }
}