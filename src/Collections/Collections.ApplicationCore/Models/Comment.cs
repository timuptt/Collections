using Ardalis.GuardClauses;
using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Comment : EntityBase<int>, IAggregateRoot
{
    public int UserProfileId { get; set; }
    
    public UserProfile UserProfile { get; set; }
    
    public int ItemId { get; set; }
    
    public Item Item { get; set; }

    public string Body { get; set; }
}