using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;

namespace Collections.Web.Services;

public class CollectionViewModelService : ICollectionViewModelService
{
    private readonly IReadRepository<UserCollection> _userCollectionsRepository;
    private readonly ICloudStorageService _cloudStorageService;

    public CollectionViewModelService(IReadRepository<UserCollection> userCollectionRepository, ICloudStorageService cloudStorageService)
    {
        _userCollectionsRepository = userCollectionRepository;
        _cloudStorageService = cloudStorageService;
    }

    
    public async Task<IEnumerable<CollectionViewModel>> GetCollectionsWithMoreItems()
    {
        throw new NotImplementedException();
    }

    public async Task<CollectionWithItemsViewModel> GetCollectionViewModelById(int id)
    {
        var specification = new UserCollectionWithItemsByIdSpecification(id);
        var collection = await _userCollectionsRepository.GetBySpecProjectedAsync<CollectionWithItemsViewModel>(specification);
        if (!string.IsNullOrWhiteSpace(collection.ImageName))
        {
            collection.ImageSignedSource = await _cloudStorageService.GetSignedUrlAsync(collection.ImageName);
        }
        return collection;
    }
}