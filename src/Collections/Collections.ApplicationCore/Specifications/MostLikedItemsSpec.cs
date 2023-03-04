using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class MostLikedItemsSpec : Specification<Item>, ISingleResultSpecification
{
    public MostLikedItemsSpec()
    {
        Query
            .OrderByDescending(i => i.Likes.Count)
            .Take(6)
            .EnableCache(nameof(MostLikedItemsSpec));
    }
}