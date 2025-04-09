using System.Diagnostics;

namespace MonkeyFinder.MauiPages;

public partial class MonkeyRatingPage : ContentPage
{
    public MonkeyRatingPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Monkey rating: " + rating.Value);

        // This will pop the page to the navigation stack
        Navigation.PopAsync();

        // This will pop the modal if the PushModalAsync was used
        // Navigation.PopModalAsync();
    }
}
