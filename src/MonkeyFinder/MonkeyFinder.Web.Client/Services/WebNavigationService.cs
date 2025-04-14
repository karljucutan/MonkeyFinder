using Microsoft.AspNetCore.Components;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder.Web.Client.Services;

public class WebNavigationService : INavigationService
{
    private readonly NavigationManager _navigationManager;

    public WebNavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public Task NavigateToRatingPageAsync(MonkeyRatingState monkeyRatingState)
    {
        _navigationManager.NavigateTo("/rating");
        return Task.CompletedTask;
    }
}
