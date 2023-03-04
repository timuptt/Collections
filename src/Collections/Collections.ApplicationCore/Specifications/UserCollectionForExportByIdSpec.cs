using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class UserCollectionForExportByIdSpec : Specification<UserCollection>
{
    public UserCollectionForExportByIdSpec(int id)
    {
        Query
            .Where(c => c.Id == id)
            .Include(c => c.Items)
                .ThenInclude(i => i.ExtraFields)
            .Include(c => c.UserProfile)
            .Include(c => c.UserCollectionTheme);
    }
}