using Ardalis.GuardClauses;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class CollectionService : ICollectionService
{
    private readonly IRepository<UserCollection> _userCollectionsRepository;
    private readonly IRepository<Item> _itemsRepository;

    public CollectionService(IRepository<UserCollection> userCollectionsRepository, IRepository<Item> itemsRepository)
    {
        _userCollectionsRepository = userCollectionsRepository;
        _itemsRepository = itemsRepository;
    }


    public async Task AddItemToCollection(int collectionId, Item item)
    {
        Guard.Against.NegativeOrZero(collectionId, nameof(collectionId));
        var collectionToAdd = await _userCollectionsRepository.GetByIdAsync(collectionId);
        Guard.Against.Null(collectionToAdd);
        collectionToAdd.AddItem(item);
        await _userCollectionsRepository.UpdateAsync(collectionToAdd);
    }

    public async Task CreateCollection(int userProfileId, int userCollectionThemeId, string title,
        string description, string imageSource = "",
        ICollection<ExtraFieldValueType> extraFieldValueTypes = null)
    {
        var collection = new UserCollection(title, description, userProfileId, userCollectionThemeId, imageSource);
        await _userCollectionsRepository.AddAsync(collection);
    }

    public async Task UpdateCollection(int id, string title, string imageSource)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        var collectionToUpdate = await _userCollectionsRepository.GetByIdAsync(id);
        Guard.Against.Null(collectionToUpdate, nameof(collectionToUpdate));
        collectionToUpdate.Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        collectionToUpdate.ImageSource = Guard.Against.Null(imageSource, nameof(imageSource));
        await _userCollectionsRepository.UpdateAsync(collectionToUpdate);
    }

    public async Task DeleteCollection(int id)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        var collectionToDelete = await _userCollectionsRepository.GetByIdAsync(id);
        Guard.Against.Null(collectionToDelete, nameof(collectionToDelete));
        await _userCollectionsRepository.DeleteAsync(collectionToDelete);
    }
}