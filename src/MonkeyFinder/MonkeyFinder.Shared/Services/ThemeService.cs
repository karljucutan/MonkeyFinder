using Microsoft.FluentUI.AspNetCore.Components;

namespace MonkeyFinder.Shared.Services;
public class ThemeService
{
    public event Action? OnThemeChanged;

    private DesignThemeModes _currentTheme = DesignThemeModes.Light;

    public DesignThemeModes CurrentTheme
    {
        get => _currentTheme;
        set
        {
            if (_currentTheme != value)
            {
                _currentTheme = value;
                OnThemeChanged?.Invoke();
            }
        }
    }
}
