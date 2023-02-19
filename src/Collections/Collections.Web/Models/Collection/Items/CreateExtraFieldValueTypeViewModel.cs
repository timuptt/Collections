using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Collection.Items;

public class CreateExtraFieldValueTypeViewModel : IMapWith<CreateExtraFieldValueTypeDto>
{
    public ValueTypes ValueType { get; set; }
    
    public string Name { get; set; }
    
    public bool IsRequired { get; set; }
    
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateExtraFieldValueTypeDto, CreateExtraFieldValueTypeViewModel>()
            .ReverseMap();
    }
}