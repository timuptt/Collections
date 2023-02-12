using Collections.Web.Models;

namespace Collections.Web.Interfaces;

public interface IHomePageViewModelService
{
    public Task<HomePageViewModel> GetHomePageViewModel();
}