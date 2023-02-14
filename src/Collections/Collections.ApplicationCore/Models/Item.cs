using Ardalis.GuardClauses;
using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Item : EntityBase<int>, IAggregateRoot
{
    public int UserCollectionId { get; set; }
    
    public UserCollection UserCollection { get; set; }
    
    public string Title { get; set; }

    public ICollection<Like> Likes { get; set; }
    
    public ICollection<ExtraField> ExtraFields { get; set; }

    public ICollection<Tag> Tags { get; set; }
    
    public Item() {}

    public Item(int collectionId, string title, ICollection<Tag> tags, ICollection<ExtraField> extraFields)
    {
        UserCollectionId = Guard.Against.NegativeOrZero(collectionId, nameof(collectionId));
        Title = Guard.Against.NullOrEmpty(title, nameof(title));
        Tags = Guard.Against.Null(tags, nameof(tags));
        ExtraFields = extraFields;
    }
}