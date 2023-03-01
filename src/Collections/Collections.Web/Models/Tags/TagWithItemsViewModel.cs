using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.Items;

namespace Collections.Web.Models.Tags;

public class TagWithItemsViewModel : IMapWith<Tag>
{
    public string Title { get; set; }

    public IList<ItemViewModel> Items { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, TagWithItemsViewModel>();
    }
}