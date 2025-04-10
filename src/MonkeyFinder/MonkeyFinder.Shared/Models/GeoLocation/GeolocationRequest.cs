namespace MonkeyFinder.Shared.Models.GeoLocation;
public class GeolocationRequest
{
    public GeolocationAccuracy DesiredAccuracy { get; set; } = GeolocationAccuracy.Medium;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}

public enum GeolocationAccuracy
{
    Low,
    Medium,
    High
}
