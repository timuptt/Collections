using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class UpdateExtraFieldDto : IMapWith<ExtraField>
{
    public int Id { get; set; }
    
    public string Value { get; set; }

    public int ExtraFieldValueTypeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraField, UpdateExtraFieldDto>()
            .ReverseMap();
    }
}