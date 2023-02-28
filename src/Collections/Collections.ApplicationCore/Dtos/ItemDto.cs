using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class ItemDto : IMapWith<Item>
{
    public int UserCollectionId { get; set; }
    
    public string Title { get; set; }

    public IEnumerable<ExtraFieldDto>? ExtraFields { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ItemDto, Item>();
    }
}