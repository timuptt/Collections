namespace Collections.Web.Interfaces;

public interface ICurrentUserProvider
{
    public int ProfileId { get; }
    public string FullName { get; }
    public bool IsAdmin { get; }

    public bool HasPermissions(int profileId);
}