using Ardalis.Specification;
using Collections.ApplicationCore.Models;

namespace Collections.ApplicationCore.Specifications;

public class MostLikedItemsSpecification : Specification<Item>, ISingleResultSpecification
{
    public MostLikedItemsSpecification()
    {
        Query
            .OrderByDescending(i => i.Likes.Count)
            .Take(6);
    }
}