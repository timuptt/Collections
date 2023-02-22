using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;

namespace Collections.ApplicationCore.Services;

public class LikesService : ILikesService
{
    private readonly IRepository<Like> _likeRepository;

    public LikesService(IRepository<Like> likeRepository)
    {
        _likeRepository = likeRepository;
    }

    public async Task Like(int itemId, int userProfileId)
    {
        var like = await _likeRepository.FirstOrDefaultAsync(new LikeSpec(userProfileId, itemId));
        if (like == null)
        {
            await _likeRepository.AddAsync(new Like() { ItemId = itemId, UserProfileId = userProfileId });
            return;
        }
        await _likeRepository.DeleteAsync(like);
    }
}