namespace MonkeyFinder.Shared.Models.GeoLocation;

public class Location
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double? Altitude { get; set; }
    public DateTimeOffset Timestamp { get; set; }

    public Location() { }

    public Location(double latitude, double longitude, double? altitude = null, DateTimeOffset? timestamp = null)
    {
        Latitude = latitude;
        Longitude = longitude;
        Altitude = altitude;
        Timestamp = timestamp ?? DateTimeOffset.UtcNow;
    }
}
