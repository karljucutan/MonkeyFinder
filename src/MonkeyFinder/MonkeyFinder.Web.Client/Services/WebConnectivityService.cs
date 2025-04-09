using Microsoft.JSInterop;
using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class WebConnectivityService(IJSRuntime jsRuntime) : IConnectivityService
{
    public async Task<ConnectivityInfo> GetConnectivityInfoAsync()
    {
        // Call the JavaScript function to get network information
        var networkInfo = await jsRuntime.InvokeAsync<NetworkInfo>("getNetworkInformation");

        var info = new ConnectivityInfo
        {
            IsConnected = networkInfo.IsSupported && networkInfo.Type != "unknown",
            ConnectionType = networkInfo.Type,
            Platform = "Web",
            AvailableConnectionProfiles = new List<string> { networkInfo.EffectiveType }
        };

        return info;
    }

    public async Task<bool> IsConnectedAsync()
    {
        var networkInfo = await jsRuntime.InvokeAsync<NetworkInfo>("getNetworkInformation");
        return networkInfo.IsSupported && networkInfo.Type != "unknown";
    }

    public async Task<string> GetConnectionTypeAsync()
    {
        var networkInfo = await jsRuntime.InvokeAsync<NetworkInfo>("getNetworkInformation");
        return networkInfo.Type;
    }

    private class NetworkInfo
    {
        public bool IsSupported { get; set; }
        public string Type { get; set; } = string.Empty;
        public string EffectiveType { get; set; } = string.Empty;
        public int Rtt { get; set; }
        public bool SaveData { get; set; }
    }
}
