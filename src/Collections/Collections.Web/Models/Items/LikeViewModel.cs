using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Items;

public class LikeViewModel : IMapWith<Like>
{
    public int UserProfileId { get; set; }
    
    public int ItemId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Like, LikeViewModel>();
    }
}