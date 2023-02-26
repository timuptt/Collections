using Collections.Shared.Interfaces;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemSearchRepository _itemSearchRepository;

    public ItemController(IItemSearchRepository itemSearchRepository)
    {
        _itemSearchRepository = itemSearchRepository;
    }

    public async Task<IActionResult> Search(string term)
    {
        return Ok(await _itemSearchRepository.SearchProjectedAsync<SearchItemViewModel>(term));
    }
}