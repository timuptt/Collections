using Collections.Shared.Interfaces;
using Collections.Shared.Models;

namespace Collections.ApplicationCore.Models;

public class UserCollectionTheme : EntityBase<int>, IAggregateRoot
{
    public string Theme { get; set; }
    
    public IEnumerable<UserCollection> UserCollections { get; set; }
}