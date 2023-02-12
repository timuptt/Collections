using Collections.Web.Models.Collection;
using Collections.Web.Models.Collection.Items;

namespace Collections.Web.Models;

public class HomePageViewModel
{
    public IEnumerable<CollectionViewModel> CollectionsWithMoreItems { get; set; }
    
    public IEnumerable<ItemViewModel> MostPopularItems { get; set; }
    
    public IEnumerable<TagViewModel> Tags { get; set; }
}