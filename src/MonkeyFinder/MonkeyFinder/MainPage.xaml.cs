using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.FluentUI.AspNetCore.Components;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder;

public partial class MainPage : ContentPage, IDisposable
{
    private readonly ThemeState _themeState;
    private bool _disposedValue;

    public MainPage(ThemeState themeState)
    {
        InitializeComponent();
        _themeState = themeState;

        // Subscribe to theme changes
        _themeState.OnThemeChanged += OnThemeChangedHandler;

        // Set the initial status bar appearance
        SetStatusBarAppearance(_themeState.CurrentTheme);

        _themeState = themeState;
    }

    private void OnThemeChangedHandler()
    {
        SetStatusBarAppearance(_themeState.CurrentTheme);
    }

    private static void SetStatusBarAppearance(DesignThemeModes theme)
    {
        if (OperatingSystem.IsAndroid() || OperatingSystem.IsIOS())
        {
            if (theme == DesignThemeModes.Dark)
            {
                // Set dark theme status bar appearance
                StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#444034"));
                StatusBar.SetStyle(StatusBarStyle.LightContent);

                var app = Application.Current;
                if (app is not null)
                    app.UserAppTheme = AppTheme.Dark;

            }
            else if (theme == DesignThemeModes.Light)
            {
                // Set light theme status bar appearance
                StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#DDAF24"));
                StatusBar.SetStyle(StatusBarStyle.DarkContent);

                var app = Application.Current;
                if (app is not null)
                    app.UserAppTheme = AppTheme.Light;
            }
            else if (theme == DesignThemeModes.System)
            {
                // Handle system theme
                var currentTheme = Application.Current?.RequestedTheme;

                if (currentTheme == AppTheme.Dark)
                {
                    // Set dark theme status bar appearance
                    StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#444034"));
                    StatusBar.SetStyle(StatusBarStyle.LightContent);

                    var app = Application.Current;
                    if (app is not null)
                        app.UserAppTheme = AppTheme.Dark;
                }
                else
                {
                    // Set light theme status bar appearance
                    StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#DDAF24"));
                    StatusBar.SetStyle(StatusBarStyle.DarkContent);

                    var app = Application.Current;
                    if (app is not null)
                        app.UserAppTheme = AppTheme.Light;
                }
            }
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // Clean up managed resources (event subscriptions)
                _themeState.OnThemeChanged -= OnThemeChangedHandler;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            _disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~MainPage()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }


    // Removed as it unsubscribes when the MonkeyRatingPage is pushed to the stack and MainPag will be OnDisappearing
    //protected override void OnDisappearing()
    //{
    //    base.OnDisappearing();
    //    // Unsubscribe from theme changes to avoid memory leaks
    //    _themeState.OnThemeChanged -= OnThemeChangedHandler;
    //}
}
