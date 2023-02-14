using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class TagsService : ITagsService
{
    private readonly IRepository<Tag> _tagRepository;

    public TagsService(IRepository<Tag> tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<Tag>> CreateTagsAsync(IEnumerable<string> tagNames)
    {
        return await _tagRepository.AddRangeAsync(tagNames.Select(n => new Tag(n)));
    }
    
    
}