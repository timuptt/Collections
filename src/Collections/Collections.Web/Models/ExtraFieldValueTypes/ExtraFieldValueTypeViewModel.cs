using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.ExtraFieldValueTypes;

public class ExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueType>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ValueTypes ValueType { get; set; }
    
    public bool IsVisible { get; set; }
    
    public bool IsRequired { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, ExtraFieldValueTypeViewModel>()
            .ReverseMap();
    }
}