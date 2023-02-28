using Collections.ApplicationCore.Dtos;

namespace Collections.ApplicationCore.Interfaces;

public interface IItemService
{
    public Task UpdateItem(UpdateItemDto itemDto);

    // public Task CreateItem(int collectionId, string title, IEnumerable<string> tags, IEnumerable<ExtraField> extraFields);
    
    public Task CreateItem(ItemDto itemDto, IEnumerable<string> tags);

    public Task WriteComment(CommentDto commentDto);
    
    public Task DeleteItem(int itemId);
}