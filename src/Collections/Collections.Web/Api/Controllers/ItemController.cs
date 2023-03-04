using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Api.Helpers;
using Collections.Web.Configuration.Options;
using Collections.Web.Filters;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Collections.Web.Api.Controllers;

[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemSearchRepository _itemSearchRepository;
    private readonly IReadRepository<Item> _itemReadRepository;
    private readonly IFilter<Item> _filter;
    private readonly IOptions<SiteOptions> _options;

    public ItemController(IItemSearchRepository itemSearchRepository, IReadRepository<Item> itemReadRepository, IFilter<Item> filter, IOptions<SiteOptions> options)
    {
        _itemSearchRepository = itemSearchRepository;
        _itemReadRepository = itemReadRepository;
        _filter = filter;
        _options = options;
    }

    [Route("api/[controller]/[action]")]
    public async Task<IActionResult> Search(string term)
    {
        return Ok(await _itemSearchRepository.SearchProjectedAsync<SearchItemViewModel>(term, _options.Value.SearchResultItemsCount));
    }

    [Route("api/[controller]/[action]")]
    public async Task<IActionResult> ItemsByTag(int tagId)
    {
        var request = new DataTableRequestHelper(Request);
        var totalRows = await GetTotalRows(tagId);
        var specification = new ItemsByTagFilteredPaginatedSpec(tagId,request.Skip, request.PageSize, request.SearchValue,
            _filter.GetSortingPredicate(request.SortColumn), request.SortColumnDirection);
        var collections = await _itemReadRepository.ListProjectedAsync<ItemViewModel>(specification);
        var jsonData = new
            { draw = request.Draw, recordsFiltered = totalRows, recordsTotal = totalRows, data = collections };
        return Ok(jsonData);
    }
    
    private async Task<int> GetTotalRows(int tagId)
    {
        var countSpecification = new ItemByTagCountSpec(tagId);
        var totalRows = await _itemReadRepository.CountAsync(countSpecification);
        return totalRows;
    }
}