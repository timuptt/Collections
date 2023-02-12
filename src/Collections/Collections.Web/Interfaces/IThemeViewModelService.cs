using Microsoft.AspNetCore.Mvc.Rendering;

namespace Collections.Web.Interfaces;

public interface IThemeViewModelService
{
    public Task<SelectList> GetThemesAsSelectList();
}