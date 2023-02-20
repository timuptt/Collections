using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Dtos;

namespace Collections.Web.Models.Collection.Items;

public class CreateCommentViewModel : IMapWith<CommentDto>
{
    public int ItemId { get; set; }
    
    public int UserProfileId { get; set; }
    
    public string Body { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCommentViewModel, CommentDto>()
            .ReverseMap();
    }
}