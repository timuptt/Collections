using Collections.ApplicationCore.Models;

namespace Collections.Shared.Interfaces;

public interface IItemSearchRepository
{
    public Task<IEnumerable<TProjectTo>> SearchProjectedAsync<TProjectTo>(string searchTerm);

    public Task AddAsync(Item item, IEnumerable<string> tags);
}