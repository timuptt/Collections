using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public sealed class ItemsByTagSpecification : Specification<Item>, ISingleResultSpecification
{
    public ItemsByTagSpecification(string tag)
    {
        Query
            .Where(i => i.Tags.Select(t => t.Title).Contains(tag))
            .Include(i => i.Tags)
            .EnableCache(nameof(ItemsByTagSpecification), tag);
    }
}