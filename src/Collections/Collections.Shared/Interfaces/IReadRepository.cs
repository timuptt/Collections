using Ardalis.Specification;

namespace Collections.Shared.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
    public Task<List<TProjectTo>> ListProjectedAsync<TProjectTo>(ISpecification<T> specification,
        CancellationToken cancellationToken = default);

    public Task<TProjectTo> GetBySpecProjectedAsync<TProjectTo>(ISpecification<T> specification,
        CancellationToken cancellationToken = default);
}