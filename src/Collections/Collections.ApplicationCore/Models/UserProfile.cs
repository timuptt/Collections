using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class UserProfile : EntityBase<int>, IAggregateRoot
{
    public string ApplicationUserId { get; set; }
    
    public string FirstName { get; set; }
    
    public string? LastName { get; set; }
    
    public string? ImageSource { get; set; }
    
    public IEnumerable<UserCollection> UserCollections { get; set; }
}