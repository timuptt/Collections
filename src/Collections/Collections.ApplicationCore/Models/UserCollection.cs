using Ardalis.GuardClauses;
using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class UserCollection : EntityBase<int>, IAggregateRoot
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public int UserProfileId { get; set; }
    
    public UserProfile UserProfile { get; set; }

    public int UserCollectionThemeId { get; set; }
    
    public UserCollectionTheme UserCollectionTheme { get; set; }

    public string? ImageSource { get; set; }
    
    public List<ExtraFieldValueType>? ExtraFieldValueTypes { get; set; }

    public ICollection<Item> Items { get; set; }

    public UserCollection()
    {
        
    }
    public UserCollection(string title, string description, int userProfileId, int userCollectionThemeId, string imageSource = "", ICollection<ExtraFieldValueType> extraFieldValueTypes = null)
    {
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
        Description = Guard.Against.NullOrWhiteSpace(description, nameof(description));
        UserProfileId = Guard.Against.NegativeOrZero(userProfileId, nameof(userProfileId));
        UserCollectionThemeId = Guard.Against.NegativeOrZero(userCollectionThemeId, nameof(userCollectionThemeId));
        ImageSource = imageSource;
        ExtraFieldValueTypes = extraFieldValueTypes.ToList();
    }

    protected internal void AddItem(Item item)
    {
        Items.Add(item);
    }
}