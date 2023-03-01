using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;

namespace Collections.Web.Models;

public class HomePageViewModel
{
    public IEnumerable<CollectionViewModel> CollectionsWithMoreItems { get; set; }
    
    public IEnumerable<CardItemViewModel> LastAddedItems { get; set; }
    
    public IEnumerable<CardItemViewModel> MostPopularItems { get; set; }
    
    public IEnumerable<TagViewModel> Tags { get; set; }
}