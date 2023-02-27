using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Interfaces;

public interface IItemService
{
    public Task UpdateItem(string id);

    public Task CreateItem(int collectionId, string title, IEnumerable<string> tags, IEnumerable<ExtraField> extraFields);

    public Task WriteComment(CommentDto commentDto);
    
    public Task DeleteItem(int itemId);
}