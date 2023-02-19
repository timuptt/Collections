using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class UpdateExtraFieldValueTypeDto : IMapWith<ExtraFieldValueType>
{
    public int Id { get; set; }
    
    public ValueTypes ValueType { get; set; }
    
    public string Name { get; set; }
    
    public bool IsRequired { get; set; }
    
    public bool IsVisible { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, UpdateExtraFieldValueTypeDto>()
            .ReverseMap();
    }
}