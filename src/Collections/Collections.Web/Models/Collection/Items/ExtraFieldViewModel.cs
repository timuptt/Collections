using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection.Items;

public class ExtraFieldViewModel : IMapWith<ExtraField>
{
    public string Id { get; set; }
    
    public string Value { get; set; }
    
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraField, ExtraFieldViewModel>();
    }
}