namespace MonkeyFinder.Shared.Models;

public class ConnectivityInfo
{
    public bool IsConnected { get; set; } // Whether the device/browser is connected to the internet
    public string ConnectionType { get; set; } = string.Empty; // Type of connection (e.g., WiFi, Cellular, Online/Offline)
    public string Platform { get; set; } = string.Empty; // Platform (e.g., MAUI, Web)
    public List<string> AvailableConnectionProfiles { get; set; } = new(); // Available connection profiles (e.g., WiFi, Ethernet)
}
