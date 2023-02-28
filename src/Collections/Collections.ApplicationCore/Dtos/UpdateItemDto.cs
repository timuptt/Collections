using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class UpdateItemDto : IMapWith<Item>
{
    public int Id { get; set; }

    public string Title { get; set; }

    public IEnumerable<UpdateExtraFieldDto> ExtraFields { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, UpdateItemDto>()
            .ReverseMap();
    }
}