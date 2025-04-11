using MonkeyFinder.Shared.Services.Abstractions;
using SharedMapLaunchOptions = MonkeyFinder.Shared.Models.Map.MapLaunchOptions;

namespace MonkeyFinder.Services;

public class MauiMapService : IMapService
{
    public async Task OpenAsync(double latitude, double longitude, SharedMapLaunchOptions options)
    {
        await Map.Default.OpenAsync(latitude, longitude, new MapLaunchOptions
        {
            Name = options.Name,
            NavigationMode = (NavigationMode)options.NavigationMode
        });
    }
}
