using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Tags;

public class CloudTagViewModel : IMapWith<Tag>
{
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public double Weight { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, CloudTagViewModel>()
            .ForMember(tagVm => tagVm.Text, opt =>
                opt.MapFrom(tag => tag.Title))
            .ForMember(tagVm => tagVm.Weight, opt =>
                opt.MapFrom(tag => (double)tag.Items.Count));
    }
}