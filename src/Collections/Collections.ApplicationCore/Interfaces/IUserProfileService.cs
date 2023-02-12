namespace Collections.ApplicationCore.Interfaces;

public interface IUserProfileService
{
    public Task UpdateUserProfile(int id, string firstName, string lastName, string imageSource);
}