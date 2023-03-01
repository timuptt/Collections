using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.ExtraFieldValueTypes;

public class CreateExtraFieldValueTypeViewModel : IMapWith<CreateExtraFieldValueTypeDto>
{
    public ValueTypes ValueType { get; set; }
    
    [DisplayName("Name")]
    public string Name { get; set; }
    
    [DisplayName("Is Required")]
    public bool IsRequired { get; set; }
    
    [DisplayName("Is Visible")]
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExtraFieldValueTypeDto, CreateExtraFieldValueTypeViewModel>()
            .ReverseMap();
    }
}