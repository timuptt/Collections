namespace Collections.Shared.Interfaces;

public interface IItemSearchRepository
{
    public Task<IEnumerable<TProjectTo>> SearchProjectedAsync<TProjectTo>(string searchTerm) where TProjectTo : class;
}