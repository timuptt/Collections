using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Interfaces;

public interface ITagsService
{
    public Task<IEnumerable<Tag>> CreateTagsAsync(IEnumerable<string> tagNames);
}