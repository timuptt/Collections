using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Items;

public class TagViewModel : IMapWith<Tag>
{
    public int Id { get; set; }

    public string Text { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, TagViewModel>()
            .ForMember(tagVm => tagVm.Text, opt =>
                opt.MapFrom(tag => tag.Title));
    }
}