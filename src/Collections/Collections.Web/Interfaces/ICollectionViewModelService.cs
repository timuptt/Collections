using Collections.Web.Models;
using Collections.Web.Models.Collection;

namespace Collections.Web.Interfaces;

public interface ICollectionViewModelService
{
    public Task<IEnumerable<CollectionViewModel>> GetCollectionsWithMoreItems();

    public Task<CollectionWithItemsViewModel> GetCollectionViewModelById(int id);
}