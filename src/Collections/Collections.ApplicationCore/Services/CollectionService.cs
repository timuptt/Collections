using Ardalis.GuardClauses;
using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class CollectionService : ICollectionService
{
    private readonly IRepository<UserCollection> _userCollectionsRepository;
    private readonly IRepository<ExtraFieldValueType> _extraFieldValueTypeRepository;
    private readonly IMapper _mapper;

    public CollectionService(IRepository<UserCollection> userCollectionsRepository,
        IRepository<ExtraFieldValueType> extraFieldValueTypeRepository, IMapper mapper)
    {
        _userCollectionsRepository = userCollectionsRepository;
        _extraFieldValueTypeRepository = extraFieldValueTypeRepository;
        _mapper = mapper;
    }
    
    public async Task AddItemToCollection(int collectionId, Item item)
    {
        Guard.Against.NegativeOrZero(collectionId, nameof(collectionId));
        var collectionToAdd = await _userCollectionsRepository.GetByIdAsync(collectionId);
        Guard.Against.Null(collectionToAdd);
        collectionToAdd.AddItem(item);
        await _userCollectionsRepository.UpdateAsync(collectionToAdd);
    }
    
    public async Task DeleteCollection(int id)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        var collectionToDelete = await _userCollectionsRepository.GetByIdAsync(id);
        Guard.Against.Null(collectionToDelete, nameof(collectionToDelete));
        await _userCollectionsRepository.DeleteAsync(collectionToDelete);
    }

    public async Task CreateCollection(int userProfileId, int userCollectionThemeId, string title,
        string description, string imageSource,
        ICollection<ExtraFieldValueType> extraFieldValueTypes)
    {
        var collection = new UserCollection(title, description, userProfileId, userCollectionThemeId, imageSource, extraFieldValueTypes);
        await _userCollectionsRepository.AddAsync(collection);
    }

    public async Task UpdateCollection(UpdateUserCollectionDto userCollectionDto)
    {
        await UpdateCollectionFields(userCollectionDto);
        if (HasNewValueTypes(userCollectionDto)) await UpdateCollectionExtraFields(userCollectionDto);
    }

    private async Task UpdateCollectionExtraFields(UpdateUserCollectionDto collectionDto)
    {
        var extraFieldValueTypes = collectionDto.NewExtraFieldValueTypes.Select(e => new ExtraFieldValueType()
            { Name = e.Name, IsRequired = e.IsRequired, IsVisible = e.IsVisible, ValueType = e.ValueType, UserCollectionId = collectionDto.Id });
        await _extraFieldValueTypeRepository.AddRangeAsync(extraFieldValueTypes);
        var collection = await AddExtraFieldsToUserCollectionItems(collectionDto);
        await _userCollectionsRepository.UpdateAsync(collection);
    }

    private async Task<UserCollection> AddExtraFieldsToUserCollectionItems(UpdateUserCollectionDto collectionDto)
    {
        var specification = new UserCollectionWithItemsAbdExtraFieldsSpec(collectionDto.Id);
        var collectionToUpdate = await _userCollectionsRepository.GetBySpecAsync(specification);
        foreach (var item in collectionToUpdate!.Items)
        {
            for (var i = 0; i < collectionToUpdate.ExtraFieldValueTypes.Count; i++)
            {
                if (i >= item.ExtraFields.Count)
                {
                    item.ExtraFields.Add(new ExtraField()
                        { Value = "", ExtraFieldValueTypeId = collectionToUpdate.ExtraFieldValueTypes[i].Id });
                }
            }
        }
        return collectionToUpdate;
    }

    private async Task UpdateCollectionFields(UpdateUserCollectionDto userCollectionDto)
    {
        var userCollectionToUpdate = await _userCollectionsRepository.GetByIdAsync(userCollectionDto.Id);
        Guard.Against.Null(userCollectionToUpdate, nameof(userCollectionToUpdate));
        _mapper.Map(userCollectionDto, userCollectionToUpdate);
        await _userCollectionsRepository.UpdateAsync(userCollectionToUpdate);
    }

    private static bool HasNewValueTypes(UpdateUserCollectionDto userCollectionDto) => 
        userCollectionDto.NewExtraFieldValueTypes != null && userCollectionDto.NewExtraFieldValueTypes.Any();
}