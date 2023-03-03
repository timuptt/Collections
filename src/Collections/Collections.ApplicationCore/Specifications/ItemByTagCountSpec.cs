using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ItemByTagCountSpec : Specification<Item>
{
    public ItemByTagCountSpec(int tagId)
    {
        Query
            .AsNoTracking()
            .Where(i => i.Tags.Any(t => t.Id == tagId));
    }
}