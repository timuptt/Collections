using Ardalis.GuardClauses;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Tag : EntityBase<int>
{
    public string Title { get; set; }
    
    public ICollection<Item> Items { get; set; }

    public Tag()
    { }

    public Tag(string title)
    {
        Title = Guard.Against.NullOrWhiteSpace(title, nameof(title));
    }
}