using Collections.ApplicationCore.Dtos;

namespace Collections.ApplicationCore.Interfaces;

public interface IItemService
{
    public Task UpdateItem(UpdateItemDto itemDto, ICollection<string>? tags);
    
    public Task CreateItem(ItemDto itemDto, IEnumerable<string> tags);

    public Task WriteComment(CommentDto commentDto);
    
    public Task DeleteItem(int itemId);
}