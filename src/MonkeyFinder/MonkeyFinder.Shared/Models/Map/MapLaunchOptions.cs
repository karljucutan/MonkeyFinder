namespace MonkeyFinder.Shared.Models.Map;

public class MapLaunchOptions
{
    public string Name { get; set; } = string.Empty;
    public NavigationMode NavigationMode { get; set; } = NavigationMode.None;
}

public enum NavigationMode
{
    None,
    Driving,
    Walking,
    Transit
}
