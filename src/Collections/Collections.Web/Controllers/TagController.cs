using Collections.ApplicationCore.Models;
using Collections.ApplicationCore.Specifications;
using Collections.Shared.Interfaces;
using Collections.Web.Models.Items;
using Collections.Web.Models.Tags;
using Microsoft.AspNetCore.Mvc;

namespace Collections.Web.Controllers;

public class TagController : Controller
{
    private readonly IReadRepository<Tag> _tagReadRepository;

    // GET
    public TagController(IReadRepository<Tag> tagReadRepository)
    {
        _tagReadRepository = tagReadRepository;
    }

    public async Task<IActionResult> Index(int id)
    {
        var specification = new TagByIdSpec(id);
        var tagVm = await _tagReadRepository.GetBySpecProjectedAsync<TagViewModel>(specification);
        return View(tagVm);
    }
}