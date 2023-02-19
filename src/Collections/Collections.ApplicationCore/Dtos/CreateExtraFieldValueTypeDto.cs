using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class CreateExtraFieldValueTypeDto : IMapWith<ExtraFieldValueType>
{
    public ValueTypes ValueType { get; set; }
    
    public string Name { get; set; }
    
    public bool IsRequired { get; set; }
    
    public bool IsVisible { get; set; }
    
    public int? UserCollectionId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldValueType, CreateExtraFieldValueTypeDto>()
            .ReverseMap();
        profile.CreateMap<List<ExtraFieldValueType>, IEnumerable<CreateExtraFieldValueTypeDto>>()
            .ReverseMap();
    }
}