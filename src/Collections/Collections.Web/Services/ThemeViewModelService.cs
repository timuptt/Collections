using Collections.ApplicationCore.Models;
using Collections.Shared.Interfaces;
using Collections.Web.Interfaces;
using Collections.Web.Models.Collection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Services;

public class ThemeViewModelService : IThemeViewModelService
{
    private readonly IReadRepository<UserCollectionTheme> _themeReadRepository;

    public ThemeViewModelService(IReadRepository<UserCollectionTheme> themeReadRepository)
    {
        _themeReadRepository = themeReadRepository;
    }

    public async Task<SelectList> GetThemesAsSelectList()
    {
        var themes = await _themeReadRepository.ListProjectedAsync<UserCollectionThemeViewModel>();
        return new SelectList(themes.Select(t => new SelectListItem(t.Theme, t.Id.ToString())),
            nameof(SelectListItem.Value), nameof(SelectListItem.Text));
    }
}