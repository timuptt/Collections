using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Api.Helpers;
using Collections.Web.Filters;
using Collections.Web.Models.Collection;
using Collections.Web.Models.Items;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Api.Controllers;

[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemSearchRepository _itemSearchRepository;
    private readonly IReadRepository<Item> _itemReadRepository;
    private readonly IFilter<Item> _filter;

    public ItemController(IItemSearchRepository itemSearchRepository, IReadRepository<Item> itemReadRepository, IFilter<Item> filter)
    {
        _itemSearchRepository = itemSearchRepository;
        _itemReadRepository = itemReadRepository;
        _filter = filter;
    }

    [Route("api/[controller]/[action]")]
    public async Task<IActionResult> Search(string term)
    {
        return Ok(await _itemSearchRepository.SearchProjectedAsync<SearchItemViewModel>(term));
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