using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;

namespace Collections.Web.Models.Collection;

public class CollectionViewModel : IMapWith<UserCollection>
{
    public int Id { get; set; }
    
    public int UserProfileId { get; set; }

    public string ProfileFullName { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string UserCollectionTheme { get; set; }
    
    public string ImageSource { get; set; }
    
    public int ItemsCount { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollection, CollectionViewModel>()
            .ForMember(collectionVm => collectionVm.UserCollectionTheme,
                opt => opt.MapFrom(collection => collection.UserCollectionTheme.Theme))
            .ForMember(collectionVm => collectionVm.ProfileFullName,
                opt => opt.MapFrom(collection =>
                    string.Join(" ", collection.UserProfile.FirstName, collection.UserProfile.LastName)))
            .ForMember(collectionVm => collectionVm.ItemsCount,
                opt => opt.MapFrom(collection => collection.Items.Count));
    }
}