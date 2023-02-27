using Ardalis.GuardClauses;
using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Tag : EntityBase<int>, IAggregateRoot
{
    public string? Title { get; set; }
    
    public ICollection<Item> Items { get; set; }

    public Tag()
    { }

    public Tag(string title)
    {
        Title = title.ToLower();
    }
}