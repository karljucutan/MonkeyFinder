using MonkeyFinder.Shared.Models.Map;

namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IMapService
{
    Task OpenAsync(double latitude, double longitude, MapLaunchOptions options);
}
