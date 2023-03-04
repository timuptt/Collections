using System.ComponentModel;
using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;
using Collections.Web.Models.ExtraFieldValueTypes;
using Collections.Web.Models.Items;

namespace Collections.Web.Models.Collection;

public class CollectionWithItemsViewModel : IMapWith<UserCollection>
{
    public int Id { get; set; }
    
    public int UserProfileId { get; set; }

    public string ProfileFullName { get; set; }
    
    [DisplayName("Title")]
    public string Title { get; set; }
    
    [DisplayName("Description")]
    public string Description { get; set; }
    
    [DisplayName("Theme")]
    public string UserCollectionTheme { get; set; }
    
    public string ImageName { get; set; }
    
    public string ImageSource { get; set; }
    
    [DisplayName("Created")]
    public DateTime AddedOn { get; set; }
    
    [DisplayName("Updated")]
    public DateTime ModifiedOn { get; set; }
    
    public IList<ItemViewModel> Items { get; set; }
    
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