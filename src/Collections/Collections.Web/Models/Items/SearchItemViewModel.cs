using AutoMapper;
using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Web.Models.Items;

public class SearchItemViewModel : IMapWith<Item>
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string AuthorName { get; set; }
    
    public string CollectionTitle { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Item, SearchItemViewModel>()
            .ForMember(itemVm => itemVm.AuthorName, opt =>
                opt.MapFrom(item => string.Join(" ", item.UserCollection.UserProfile.FirstName,
                    item.UserCollection.UserProfile.LastName)))
            .ForMember(itemVm => itemVm.CollectionTitle, opt =>
                opt.MapFrom(item => item.UserCollection.Title));
    }
}