using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Dtos;

public class CommentDto : IMapWith<Comment>
{
    public int ItemId { get; set; }
    
    public int UserProfileId { get; set; }
    
    public string Body { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CommentDto, Comment>()
            .ReverseMap();
    }
}