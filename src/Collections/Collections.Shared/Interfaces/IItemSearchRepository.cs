using Collections.ApplicationCore.Common.Mappings;
using Collections.ApplicationCore.Models;

namespace Collections.Shared.Interfaces;

public interface IItemSearchRepository
{
    public Task<IEnumerable<TProjectTo>> SearchProjectedAsync<TProjectTo>(string searchTerm) where TProjectTo : class, IMapWith<Item>;
}