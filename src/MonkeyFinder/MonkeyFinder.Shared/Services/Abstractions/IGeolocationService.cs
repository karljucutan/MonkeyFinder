using MonkeyFinder.Shared.Models.GeoLocation;

namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IGeolocationService
{
    double CalculateDistance(Location location1, Location location2, DistanceUnits units);
    Task<Location?> GetCurrentLocationAsync(GeolocationRequest request);
    Task<Location?> GetLastKnownLocationAsync();
}
