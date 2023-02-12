using Ardalis.Specification;

namespace Collections.Shared.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{ }