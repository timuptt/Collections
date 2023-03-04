using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Configuration.Options;
using Collections.Web.Interfaces;
using Collections.Web.Models;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;
using Microsoft.Extensions.Options;

namespace Collections.Web.Services;

public class HomePageViewModelService : IHomePageViewModelService
{
    private readonly IReadRepository<UserCollection> _userCollectionsRepository;
    private readonly IReadRepository<Item> _itemsReadRepository;
    private readonly IOptions<SiteOptions> _options;

    public HomePageViewModelService(IReadRepository<UserCollection> userCollectionsRepository, IReadRepository<Item> itemsReadRepository, IOptions<SiteOptions> options)
    {
        _userCollectionsRepository = userCollectionsRepository;
        _itemsReadRepository = itemsReadRepository;
        _options = options;
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
        var specification = new UserCollectionsWithMoreItemsSpec(_options.Value.HomePageCollectionsCount);
        return await _userCollectionsRepository.ListProjectedAsync<CollectionViewModel>(specification);
    }

    private async Task<IEnumerable<CardItemViewModel>> GetMostPopularItems()
    {
        var specification = new MostLikedItemsSpec(_options.Value.HomePageItemsCount);
        return await _itemsReadRepository.ListProjectedAsync<CardItemViewModel>(specification);
    }
    
    private async Task<IEnumerable<CardItemViewModel>> GetLastAddedItems()
    {
        var specification = new LastItemsSpecification(_options.Value.HomePageItemsCount);
        return await _itemsReadRepository.ListProjectedAsync<CardItemViewModel>(specification);
    }
}