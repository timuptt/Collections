using AutoMapper;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Collections.Web.Controllers;

public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IReadRepository<ExtraFieldValueType> _extraFieldReadRepository;
    private readonly IMapper _mapper;

    public ItemController(IItemService itemService, IMapper mapper, IReadRepository<ExtraFieldValueType> extraFieldReadRepository)
    {
        _itemService = itemService;
        _mapper = mapper;
        _extraFieldReadRepository = extraFieldReadRepository;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Create(CreateItemViewModel request)
    {
        var specification = new ExtraFieldValueTypesSpec(request.UserCollectionId);
        var extraFieldValueTypes = await _extraFieldReadRepository.ListProjectedAsync<ExtraFieldValueTypeViewModel>(specification);
        request.ExtraFields = new List<CreateExtraFieldViewModel>();
        foreach (var type in extraFieldValueTypes)
        {
            request.ExtraFields.Add(new CreateExtraFieldViewModel() { ExtraFieldValueType = type });
        }
        return View(request);
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem(CreateItemViewModel request)
    {
        if (!ModelState.IsValid) return View("Create", request);
        await _itemService.CreateItem(request.UserCollectionId, request.Title, new List<Tag>(),
            request.ExtraFields.Select(f => new ExtraField()
                { Value = f.Value, ExtraFieldValueTypeId = f.ExtraFieldValueTypeId }));
        return RedirectToAction("Index", "Home");

    }
}