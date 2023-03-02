using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionWithItemsAndExtraFieldsSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionWithItemsAndExtraFieldsSpec(int id)
    {
        Query
            .Where(c => c.Id == id)
            .Include(c => c.ExtraFieldValueTypes)
            .Include(c => c.Items)
            .ThenInclude(c => c.ExtraFields)
            .EnableCache(nameof(UserCollectionWithItemsAndExtraFieldsSpec), id);
    }
}