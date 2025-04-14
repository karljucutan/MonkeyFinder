using System.Diagnostics;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder.MauiPages;

public partial class MonkeyRatingPage : ContentPage
{
    private readonly MonkeyRatingState _monkeyRatingState;

    public MonkeyRatingPage(MonkeyRatingState monkeyRatingState)
    {
        InitializeComponent();

        _monkeyRatingState = monkeyRatingState;
        rating.Value = monkeyRatingState.GetRating(monkeyRatingState.SelectedMonkey!);
    }

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Monkey rating: " + rating.Value);

        // This will pop the page to the navigation stack
        Navigation.PopAsync();

        // This will pop the modal if the PushModalAsync was used
        // Navigation.PopModalAsync();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        _monkeyRatingState.AddOrUpdateRating(_monkeyRatingState.SelectedMonkey!, rating.Value);

        base.OnNavigatedFrom(args);
    }
}
