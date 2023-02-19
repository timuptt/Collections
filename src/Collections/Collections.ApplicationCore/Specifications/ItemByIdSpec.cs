using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class ItemByIdSpec : Specification<Item>, ISingleResultSpecification
{
    public ItemByIdSpec(int id)
    {
        Query
            .Where(i => i.Id == id)
            .Include(i => i.UserCollection)
            .Include(i => i.ExtraFields)
            .Include(i => i.Comments);
    }
}