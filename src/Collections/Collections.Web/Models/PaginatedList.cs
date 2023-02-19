using Ardalis.Specification;
using Collections.Shared.Interfaces;

namespace Collections.Web.Models;

public class PaginatedList<T, TSource> : List<T> where TSource : class, IAggregateRoot
{
    public int PageIndex { get; init; }
    
    public int TotalPages { get; init; }
    
    public bool PreviousPage => PageIndex > 1;

    public bool NextPage => PageIndex < TotalPages;

    private PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public static async Task<PaginatedList<T, TSource>> CreateAsync(IReadRepository<TSource> repository,
        ISpecification<TSource> itemsSpec, ISpecification<TSource> countSpec, int pageIndex, int pageSize)
    {
        var count = await repository.CountAsync(countSpec);
        var items = await repository.ListProjectedAsync<T>(itemsSpec);
        return new PaginatedList<T, TSource>(items, count, pageIndex, pageSize);
    }
}