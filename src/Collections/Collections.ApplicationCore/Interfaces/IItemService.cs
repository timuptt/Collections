using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Interfaces;

public interface IItemService
{
    public Task UpdateItem(string id);

    public Task CreateItem(int collectionId, string title, IEnumerable<Tag> tags, IEnumerable<ExtraField> extraFields);
}