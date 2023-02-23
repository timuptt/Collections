namespace Collections.Shared.Interfaces;

public interface IUserManagementService<T>
{
    IQueryable<T> ListAllUsersPaginated(int skip = 0, int take = int.MaxValue);

    public Task BlockUser(string userId);
    public Task UnlockUser(string userId);
    public Task DeleteUser(string userId);
    public Task MakeAdmin(string userId);
    public Task RemoveAdmin(string userId);
}