using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Interfaces;

public interface ICollectionService
{
    public Task AddItemToCollection(int collectionId, Item item);

    public Task CreateCollection(int userProfileId, int userCollectionThemeId, string title, string description,
        string imageSource, ICollection<ExtraFieldValueType> extraFieldValueTypes);

    public Task UpdateCollection(UpdateUserCollectionDto userCollectionDto);

    public Task DeleteCollection(int id);
}