namespace Collections.ApplicationCore.Interfaces;

public interface ILikesService
{
    public Task Like(int itemId, int userProfileId);
}