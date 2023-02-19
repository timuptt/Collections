using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionWithItemsAbdExtraFieldsSpec : Specification<UserCollection>, ISingleResultSpecification
{
    public UserCollectionWithItemsAbdExtraFieldsSpec(int id)
    {
        Query
            .Where(c => c.Id == id)
            .Include(c => c.ExtraFieldValueTypes)
            .Include(c => c.Items)
            .ThenInclude(c => c.ExtraFields);
    }
}