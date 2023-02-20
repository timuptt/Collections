using Ardalis.GuardClauses;
using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class ItemService : IItemService
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<Comment> _commentRepository;
    private readonly IMapper _mapper;

    public ItemService(IRepository<Item> itemRepository, IRepository<Comment> commentRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _commentRepository = commentRepository;
        _mapper = mapper;
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

    public async Task WriteComment(CommentDto commentDto)
    {
        var comment = _mapper.Map<Comment>(commentDto);
        await _commentRepository.AddAsync(comment);
    }

    public async Task DeleteItem(int itemId)
    {
        Guard.Against.NegativeOrZero(itemId);
        var itemToDelete = await _itemRepository.GetByIdAsync(itemId);
        Guard.Against.Null(itemToDelete);
        await _itemRepository.DeleteAsync(itemToDelete);
    }
}