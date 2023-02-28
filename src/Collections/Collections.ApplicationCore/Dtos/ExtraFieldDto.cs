using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class ExtraFieldDto : IMapWith<ExtraField>
{
    public string Value { get; set; }
    
    public int ExtraFieldValueTypeId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ExtraFieldDto, ExtraField>();
    }
}


