using Ardalis.GuardClauses;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class Comment : EntityBase<int>
{
    public string ApplicationUserId { get; set; }
    
    public int UserProfileId { get; set; }
    
    public UserProfile UserProfile { get; set; }
    
    public int ItemId { get; set; }
    
    public Item Item { get; set; }

    public string Body { get; set; }

    public Comment()
    { }

    public Comment(string applicationUserId, string body)
    {
        ApplicationUserId = Guard.Against.NullOrWhiteSpace(applicationUserId, nameof(applicationUserId));
        Body = Guard.Against.NullOrEmpty(body, nameof(body));
    }
}