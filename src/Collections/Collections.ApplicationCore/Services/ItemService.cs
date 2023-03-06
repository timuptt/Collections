using Ardalis.GuardClauses;
using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class ItemService : IItemService
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IRepository<Comment> _commentRepository;
    private readonly IReadRepository<Tag> _tagReadRepository;
    private readonly IMapper _mapper;

    public ItemService(IRepository<Item> itemRepository, IRepository<Comment> commentRepository, IMapper mapper,
        IReadRepository<Tag> tagReadRepository)
    {
        _itemRepository = itemRepository;
        _commentRepository = commentRepository;
        _mapper = mapper;
        _tagReadRepository = tagReadRepository;
    }

    public async Task UpdateItem(UpdateItemDto itemDto, ICollection<string>? tags)
    {
        var specification = new ItemWithTagsByIdSpec(itemDto.Id);
        var itemToUpdate = await _itemRepository.FirstOrDefaultAsync(specification);
        Guard.Against.Null(itemToUpdate);
        _mapper.Map(itemDto, itemToUpdate);
        await ProcessUpdateTags(tags, itemToUpdate);
        await _itemRepository.UpdateAsync(itemToUpdate);
    }

    

    public async Task CreateItem(ItemDto itemDto, IEnumerable<string>? tags)
    {
        Guard.Against.Null(itemDto);
        var item = _mapper.Map<Item>(itemDto);
        if(tags != null) await ProcessTags(tags, item);
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
    
    private async Task ProcessTags(IEnumerable<string> tags, Item item)
    {
        item.Tags = new List<Tag>();
        foreach (var tag in tags)
        {
            if (int.TryParse(tag, out var tagId))
            {
                var dbTag = await _tagReadRepository.GetByIdAsync(tagId);
                if (dbTag != null) item.Tags.Add(dbTag);
                continue;
            }
            item.Tags.Add(new Tag(tag));
        }
    }
    
    private async Task ProcessUpdateTags(IEnumerable<string> tags, Item itemToUpdate)
    {
        if (!tags.Any())
        {
            itemToUpdate.Tags = new List<Tag>();
            return;
        }
        await ProcessTags(tags, itemToUpdate);
    }
}