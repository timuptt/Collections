using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ItemWithTagsByIdSpec : Specification<Item>, ISingleResultSpecification
{
    public ItemWithTagsByIdSpec(int id)
    {
        Query
            .Where(i => i.Id == id)
            .Include(i => i.Tags);
    }
}