namespace MonkeyFinder;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Provides a hierarchical navigation experience where you're able to navigate through pages, forwards and backwards, as desired.
        // It's recommended that a NavigationPage should only be populated with ContentPage objects.
        return new Window(new NavigationPage(new MainPage())
        {
            BarBackgroundColor = Color.FromArgb("#ffc107"),
            BarTextColor = Colors.White,
        });
        // This is a window with only 1 ContentPage
        //return new Window(new MainPage()) { Title = "MonkeyFinder" };
    }
}
