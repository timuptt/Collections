using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class ItemService : IItemService
{
    private readonly IRepository<Item> _itemRepository;

    public ItemService(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task UpdateItem(string id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateItem(int collectionId, string title, IEnumerable<Tag> tags, IEnumerable<ExtraField> extraFields)
    {
        var item = new Item(collectionId, title, tags.ToList(), extraFields.ToList());
        await _itemRepository.AddAsync(item);
    }
}