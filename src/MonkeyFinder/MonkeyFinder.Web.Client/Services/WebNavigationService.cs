using Microsoft.AspNetCore.Components;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class WebNavigationService : INavigationService
{
    private readonly NavigationManager _navigationManager;

    public WebNavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public Task NavigateToRatingPageAsync()
    {
        _navigationManager.NavigateTo("/rating");
        return Task.CompletedTask;
    }
}
