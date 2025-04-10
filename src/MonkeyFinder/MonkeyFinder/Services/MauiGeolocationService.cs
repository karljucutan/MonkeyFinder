using MonkeyFinder.Shared.Services.Abstractions;
using GeolocationAccuracy = Microsoft.Maui.Devices.Sensors.GeolocationAccuracy;
using GeolocationRequest = Microsoft.Maui.Devices.Sensors.GeolocationRequest;
using SharedGeolocationLocation = MonkeyFinder.Shared.Models.GeoLocation.Location;
using SharedGeoLocationRequest = MonkeyFinder.Shared.Models.GeoLocation.GeolocationRequest;

namespace MonkeyFinder.Services;

public class MauiGeolocationService : IGeolocationService
{
    public async Task<SharedGeolocationLocation?> GetCurrentLocationAsync(SharedGeoLocationRequest request)
    {
        try
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest(
                (GeolocationAccuracy)request.DesiredAccuracy,
                request.Timeout));

            if (location is null)
                return null;

            return new SharedGeolocationLocation(
            location.Latitude,
            location.Longitude,
            location.Altitude,
            location.Timestamp);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting current location: {ex.Message}");
            return null;
        }
    }

    public async Task<SharedGeolocationLocation?> GetLastKnownLocationAsync()
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location is null)
                return null;

            return new SharedGeolocationLocation
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Altitude = location.Altitude,
                Timestamp = location.Timestamp
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting last known location: {ex.Message}");
            return null;
        }
    }

    public double CalculateDistance(
        SharedGeolocationLocation location1,
        SharedGeolocationLocation location2,
        Shared.Models.GeoLocation.DistanceUnits units)
    {
        var locationStart = new Location(location1.Latitude, location1.Longitude);
        var locationEnd = new Location(location2.Latitude, location2.Longitude);
        locationEnd.CalculateDistance(locationStart, DistanceUnits.Kilometers);
        var result = Location.CalculateDistance(locationStart, locationEnd, (DistanceUnits)units);

        return result;
    }
}
