using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class MostLikedItemsSpec : Specification<Item>, ISingleResultSpecification
{
    public MostLikedItemsSpec(int take)
    {
        Query
            .OrderByDescending(i => i.Likes.Count)
            .EnableCache(nameof(MostLikedItemsSpec))
            .Take(take);

    }
}