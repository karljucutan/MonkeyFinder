using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
using Microsoft.FluentUI.AspNetCore.Components;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder;

public partial class MainPage : ContentPage
{
    private readonly ThemeState _themeState;

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
            }
            else if (theme == DesignThemeModes.Light)
            {
                // Set light theme status bar appearance
                StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#DDAF24"));
                StatusBar.SetStyle(StatusBarStyle.DarkContent);
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
                }
                else
                {
                    // Set light theme status bar appearance
                    StatusBar.SetColor(Microsoft.Maui.Graphics.Color.FromArgb("#DDAF24"));
                    StatusBar.SetStyle(StatusBarStyle.DarkContent);
                }
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        // Unsubscribe from theme changes to avoid memory leaks
        _themeState.OnThemeChanged -= OnThemeChangedHandler;
    }
}
