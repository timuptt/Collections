using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;

namespace Collections.Web.Services;

public class CollectionViewModelService : ICollectionViewModelService
{
    private readonly IReadRepository<UserCollection> _userCollectionsRepository;

    public CollectionViewModelService(IReadRepository<UserCollection> userCollectionRepository)
    {
        _userCollectionsRepository = userCollectionRepository;
    }

    
    public async Task<IEnumerable<CollectionViewModel>> GetCollectionsWithMoreItems()
    {
        throw new NotImplementedException();
    }

    public async Task<CollectionWithItemsViewModel> GetCollectionViewModelById(int id)
    {
        var specification = new UserCollectionWithItemsByIdSpecification(id);
        return await _userCollectionsRepository.GetBySpecProjectedAsync<CollectionWithItemsViewModel>(specification);
    }
}