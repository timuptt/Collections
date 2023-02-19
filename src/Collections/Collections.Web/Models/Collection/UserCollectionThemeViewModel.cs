using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection;

public class UserCollectionThemeViewModel : IMapWith<UserCollectionTheme>
{
    public int Id { get; set; }
    public string Theme { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollectionTheme, UserCollectionThemeViewModel>();
    }
}