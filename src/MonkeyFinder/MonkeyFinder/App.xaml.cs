using MonkeyFinder.Shared.States;

namespace MonkeyFinder;

public partial class App : Application
{
    private readonly ThemeState _themeState;

    public App(ThemeState themeState)
    {
        InitializeComponent();
        _themeState = themeState;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Provides a hierarchical navigation experience where you're able to navigate through pages, forwards and backwards, as desired.
        // It's recommended that a NavigationPage should only be populated with ContentPage objects.
        return new Window(new NavigationPage(new MainPage(_themeState))
        {
            BarBackgroundColor = Color.FromArgb("#ffc107"),
            BarTextColor = Colors.White,
        });
        // This is a window with only 1 ContentPage
        //return new Window(new MainPage()) { Title = "MonkeyFinder" };
    }
}
