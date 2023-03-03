using AutoMapper;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;

namespace Collections.Web.Services;

public class HomePageViewModelService : IHomePageViewModelService
{
    private readonly IMapper _mapper;
    private readonly IReadRepository<UserCollection> _userCollectionsRepository;
    private readonly IReadRepository<Item> _itemsReadRepository;

    public HomePageViewModelService(IReadRepository<UserCollection> userCollectionsRepository, IMapper mapper, IReadRepository<Item> itemsReadRepository)
    {
        _userCollectionsRepository = userCollectionsRepository;
        _itemsReadRepository = itemsReadRepository;
        _mapper = mapper;
    }
    
    public async Task<HomePageViewModel> GetHomePageViewModel()
    {
        var homePageViewModel = new HomePageViewModel()
        {
            CollectionsWithMoreItems = await GetCollectionsWithMoreItems(),
            MostPopularItems = await GetMostPopularItems(),
            LastAddedItems = await GetLastAddedItems()
        };
        return homePageViewModel;
    }

    private async Task<IEnumerable<CollectionViewModel>> GetCollectionsWithMoreItems()
    {
        var specification = new UserCollectionsWithMoreItemsSpec();
        return await _userCollectionsRepository.ListProjectedAsync<CollectionViewModel>(specification);
    }

    private async Task<IEnumerable<CardItemViewModel>> GetMostPopularItems()
    {
        var specification = new MostLikedItemsSpecification();
        return await _itemsReadRepository.ListProjectedAsync<CardItemViewModel>(specification);
    }
    
    private async Task<IEnumerable<CardItemViewModel>> GetLastAddedItems()
    {
        var specification = new LastItemsSpecification();
        return await _itemsReadRepository.ListProjectedAsync<CardItemViewModel>(specification);
    }
}