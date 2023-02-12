using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models;
using Collections.Web.Models.Collection;

namespace Collections.Web.Services;

public class HomePageViewModelService : IHomePageViewModelService
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<UserCollection> _userCollectionsRepository;

    public HomePageViewModelService(IReadRepository<UserCollection> userCollectionsRepository, IMapper mapper)
    {
        _userCollectionsRepository = userCollectionsRepository;
        _mapper = mapper;
    }
    
    public async Task<HomePageViewModel> GetHomePageViewModel()
    {
        var homePageViewModel = new HomePageViewModel()
        {
            CollectionsWithMoreItems = await GetCollectionsWithMoreItems()
        };
        return homePageViewModel;
    }

    private async Task<IEnumerable<CollectionViewModel>> GetCollectionsWithMoreItems()
    {
        var specification = new UserCollectionsWithMoreItemsSpecification();
        return await _userCollectionsRepository.ListProjectedAsync<CollectionViewModel>(specification);
    }
}