using MonkeyFinder.MauiPages;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder.Services;

public class MauiNavigationService : INavigationService
{
    public async Task NavigateToRatingPageAsync(MonkeyRatingState monkeyRatingState)
    {
        var currentPage = Application.Current?.Windows[0].Page;

        if (currentPage != null)
        {
            // This will push the page to the navigation stack
            await currentPage.Navigation.PushAsync(new MonkeyRatingPage(monkeyRatingState), true);


            // This will push the page as a modal. A modal page encourages users to complete a self-contained task that cannot be navigated away from until the task is completed or cancelled.
            //await currentPage.Navigation.PushModalAsync(new MonkeyRatingPage(), true);
        }
    }
}
