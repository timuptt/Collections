using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class CreateUserCollectionDto : IMapWith<UserCollection>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int UserProfileId { get; set; }
    
    public int UserCollectionThemeId { get; set; }
    
    public string? ImageSource { get; set; }
    
    public string? ImageName { get; set; }
    
    public List<CreateExtraFieldValueTypeDto>? ExtraFieldValueTypes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateUserCollectionDto, UserCollection>();
    }
}