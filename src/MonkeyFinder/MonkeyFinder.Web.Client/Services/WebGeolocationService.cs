using Microsoft.JSInterop;
using MonkeyFinder.Shared.Models.GeoLocation;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class WebGeolocationService : IGeolocationService
{
    const double EarthRadiusKm = 6371.0;
    const double EarthRadiusMiles = 3958.8;

    private readonly IJSRuntime _jsRuntime;

    public WebGeolocationService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task<Location?> GetCurrentLocationAsync(GeolocationRequest request)
    {
        try
        {
            var position = await _jsRuntime.InvokeAsync<GeolocationPosition>("getUserLocation");
            return new Location(position.Coords.Latitude, position.Coords.Longitude, position.Coords.Altitude, DateTimeOffset.UtcNow);
        }
        catch (JSException ex)
        {
            Console.WriteLine($"Error getting current location: {ex.Message}");
            return null;
        }
    }

    public Task<Location?> GetLastKnownLocationAsync()
    {
        // On maui, it probably saved/cache the last known location and has an expiration time.

        // The browser's Geolocation API does not provide a "last known location" concept.
        return Task.FromResult<Location?>(null);
    }

    public double CalculateDistance(Location location1, Location location2, DistanceUnits units)
    {
        var latitude1 = DegreesToRadians(location1.Latitude);
        var longitude1 = DegreesToRadians(location1.Longitude);
        var latitude2 = DegreesToRadians(location2.Latitude);
        var longitude2 = DegreesToRadians(location2.Longitude);

        var latitudeDifference = latitude2 - latitude1;
        var longituteDifference = longitude2 - longitude1;

        var a = Math.Pow(Math.Sin(latitudeDifference / 2), 2) +
                   Math.Cos(latitude1) * Math.Cos(latitude2) * Math.Pow(Math.Sin(longituteDifference / 2), 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        var radius = units == DistanceUnits.Kilometers ? EarthRadiusKm : EarthRadiusMiles;
        return radius * c;
    }

    private static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    private class GeolocationPosition
    {
        public GeolocationCoordinates Coords { get; set; } = new();
    }

    private class GeolocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Altitude { get; set; }
    }
}
