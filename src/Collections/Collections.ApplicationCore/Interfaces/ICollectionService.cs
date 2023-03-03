using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Interfaces;

public interface ICollectionService
{
    public Task CreateCollection(CreateUserCollectionDto collectionDto);

    public Task UpdateCollection(UpdateUserCollectionDto userCollectionDto);

    public Task DeleteCollection(int id);
}