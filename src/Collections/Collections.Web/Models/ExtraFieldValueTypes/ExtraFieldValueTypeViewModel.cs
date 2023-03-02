using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.ExtraFieldValueTypes;

public class ExtraFieldValueTypeViewModel : IMapWith<ExtraFieldValueType>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public ValueTypes ValueType { get; set; }
    
    [DisplayName("Is Required")]
    public bool IsRequired { get; set; }
    
    [DisplayName("Is Visible")]
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, ExtraFieldValueTypeViewModel>()
            .ReverseMap();
    }
}