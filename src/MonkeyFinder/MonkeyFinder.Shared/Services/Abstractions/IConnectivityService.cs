namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IConnectivityService
{
    Task<ConnectivityInfo> GetConnectivityInfoAsync(); // Get detailed connectivity info
    Task<bool> IsConnectedAsync(); // Check if connected to the internet
    Task<string> GetConnectionTypeAsync(); // Get the current connection type
}
