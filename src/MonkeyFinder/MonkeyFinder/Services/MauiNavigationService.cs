using MonkeyFinder.MauiPages;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Services;

public class MauiNavigationService : INavigationService
{
    public async Task NavigateToRatingPageAsync()
    {
        var currentPage = Application.Current?.Windows[0].Page;
        var currentPage2 = Application.Current?.MainPage.Navigation.NavigationStack.FirstOrDefault();
        var currentPage3 = Application.Current?.MainPage;

        if (currentPage != null)
        {
            await currentPage.Navigation.PushModalAsync(new MonkeyRatingPage());
        }
    }
}
