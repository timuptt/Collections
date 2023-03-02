using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Api.Helpers;
using Collections.Web.Filters;
using Collections.Web.Models.Collection;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Api.Controllers;

[ApiController]
public class CollectionController : ControllerBase
{
    private readonly IReadRepository<UserCollection> _collectionReadRepository;
    private readonly IFilter<UserCollection> _filter;

    public CollectionController(IReadRepository<UserCollection> collectionReadRepository,
        IFilter<UserCollection> filter)
    {
        _collectionReadRepository = collectionReadRepository;
        _filter = filter;
    }

    [HttpPost]
    [Route("api/[controller]/[action]")]
    public async Task<IActionResult> GetCollections(int userId = 0)
    {
        var request = new DataTableRequestHelper(Request);
        var totalRows = await GetTotalRows(userId);
        var specification = new UserCollectionFilteredPagedSpec(request.Skip, request.PageSize, request.SearchValue,
            _filter.GetOrderPredicate(request.SortColumn), request.SortColumnDirection, userId);
        var collections = await _collectionReadRepository.ListProjectedAsync<CollectionViewModel>(specification);
        var jsonData = new
            { draw = request.Draw, recordsFiltered = totalRows, recordsTotal = totalRows, data = collections };

        return Ok(jsonData);
    }

    private async Task<int> GetTotalRows(int userId)
    {
        var countSpecification = new UserCollectionCountSpec(userId);
        var totalRows = await _collectionReadRepository.CountAsync(countSpecification);
        return totalRows;
    }
}

