using System.ComponentModel;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;
using AutoMapper;

namespace Collections.Web.Models.UserProfile;

public class CollectionForUserProfileViewModel : IMapWith<UserCollection>
{
    [DisplayName("Id")]
    public int Id { get; set; }
    
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [DisplayName("Description")]
    public string Description { get; set; }
    
    [DisplayName("Items count")]
    public int ItemsCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollection, CollectionForUserProfileViewModel>()
            .ForMember(collectionVm => collectionVm.ItemsCount,
                opt => opt.MapFrom(collection => collection.Items.Count));
    }
}