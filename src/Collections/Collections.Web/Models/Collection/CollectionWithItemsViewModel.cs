using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.Web.Common.Mappings;
using Collections.Web.Models.Collection.Items;

namespace Collections.Web.Models.Collection;

public class CollectionWithItemsViewModel : IMapWith<UserCollection>
{
    public int Id { get; set; }
    
    public int UserProfileId { get; set; }

    public string ProfileFullName { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string UserCollectionTheme { get; set; }
    
    public string ImageSource { get; set; }
    
    public IEnumerable<ItemViewModel> Items { get; set; }
    
    public IEnumerable<ExtraFieldValueTypeViewModel> ExtraFieldValueTypes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UserCollection, CollectionWithItemsViewModel>()
            .ForMember(collectionVm => collectionVm.UserCollectionTheme,
                opt => opt.MapFrom(collection => collection.UserCollectionTheme.Theme))
            .ForMember(collectionVm => collectionVm.ProfileFullName,
                opt => opt.MapFrom(collection =>
                    string.Join(" ", collection.UserProfile.FirstName, collection.UserProfile.LastName)))
            .ForMember(collectionVm => collectionVm.Items,
                opt => opt.MapFrom(collection => collection.Items));
    }
}