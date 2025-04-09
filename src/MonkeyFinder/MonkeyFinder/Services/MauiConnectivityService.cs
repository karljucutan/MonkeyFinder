using MonkeyFinder.Shared.Services.Abstractions;
using Microsoft.Maui.Networking;
using MonkeyFinder.Shared.Models;

namespace MonkeyFinder.Services;

public class MauiConnectivityService : IConnectivityService
{
    public Task<ConnectivityInfo> GetConnectivityInfoAsync()
    {
        var info = new ConnectivityInfo
        {
            IsConnected = Connectivity.Current.NetworkAccess == NetworkAccess.Internet,
            ConnectionType = string.Join(", ", Connectivity.Current.ConnectionProfiles), // e.g., WiFi, Cellular
            Platform = "MAUI",
            AvailableConnectionProfiles = Connectivity.Current.ConnectionProfiles.Select(p => p.ToString()).ToList()
        };

        return Task.FromResult(info);
    }

    public Task<bool> IsConnectedAsync()
    {
        return Task.FromResult(Connectivity.Current.NetworkAccess == NetworkAccess.Internet);
    }

    public Task<string> GetConnectionTypeAsync()
    {
        var connectionType = string.Join(", ", Connectivity.Current.ConnectionProfiles);
        return Task.FromResult(connectionType);
    }
}
