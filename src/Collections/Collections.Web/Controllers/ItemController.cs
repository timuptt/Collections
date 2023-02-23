using AutoMapper;
using Collections.ApplicationCore.Dtos;
using Collections.ApplicationCore.Interfaces;
using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Constants.Identity;
using Collections.Shared.Interfaces;
using Collections.Web.Hubs;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection.Items;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Collections.Web.Controllers;

[Authorize]
public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IReadRepository<ExtraFieldValueType> _extraFieldReadRepository;
    private readonly IReadRepository<Item> _itemReadRepository;
    private readonly IMapper _mapper;
    private readonly IHubContext<CommentsHub> _commentsHub;
    private readonly ILikesService _likesService;
    private readonly ICurrentUserProvider _currentUser;

    public ItemController(IItemService itemService, IMapper mapper,
        IReadRepository<ExtraFieldValueType> extraFieldReadRepository, IReadRepository<Item> itemReadRepository,
        IHubContext<CommentsHub> commentsHub, ILikesService likesService, ICurrentUserProvider currentUser)
    {
        _itemService = itemService;
        _mapper = mapper;
        _extraFieldReadRepository = extraFieldReadRepository;
        _itemReadRepository = itemReadRepository;
        _commentsHub = commentsHub;
        _likesService = likesService;
        _currentUser = currentUser;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var specification = new ItemByIdSpec(id);
        var itemViewModel = await _itemReadRepository.GetBySpecProjectedAsync<ItemExtendedViewModel>(specification);
        return View(itemViewModel);
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
            request.ExtraFields!.Select(f => new ExtraField()
                { Value = f.Value, ExtraFieldValueTypeId = f.ExtraFieldValueTypeId }));
        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> WriteComment(CreateCommentViewModel request)
    {
        request.UserProfileId = _currentUser.ProfileId;
        await _itemService.WriteComment(_mapper.Map<CommentDto>(request));
        await _commentsHub.Clients.Groups(request.ItemId.ToString())
            .SendAsync("ReceiveMessage", request.UserProfileId, _currentUser.FullName, request.Body);
        return RedirectToAction("Details", "Item",new{ id = request.ItemId });
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _itemService.DeleteItem(id);
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> LikeItem(int itemId)
    {
        await _likesService.Like(itemId, _currentUser.ProfileId);
        return RedirectToAction("Details", "Item", new { id = itemId });
    }

    public async Task<IActionResult> Update(int itemId)
    {
        throw new NotImplementedException();
    }
}