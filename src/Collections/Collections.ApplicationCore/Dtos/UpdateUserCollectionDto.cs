using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class UpdateUserCollectionDto : IMapWith<UserCollection>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }

    public string? ImageSource { get; set; }
    
    public IEnumerable<UpdateExtraFieldValueTypeDto>? ExtraFieldValueTypes { get; set; }
    
    public IEnumerable<CreateExtraFieldValueTypeDto>? NewExtraFieldValueTypes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollection, UpdateUserCollectionDto>()
            .ReverseMap();
    }
}