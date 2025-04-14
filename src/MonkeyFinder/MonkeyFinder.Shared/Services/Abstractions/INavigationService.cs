using MonkeyFinder.Shared.States;

namespace MonkeyFinder.Shared.Services.Abstractions;

public interface INavigationService
{
    Task NavigateToRatingPageAsync(MonkeyRatingState monkeyRatingState);
}
