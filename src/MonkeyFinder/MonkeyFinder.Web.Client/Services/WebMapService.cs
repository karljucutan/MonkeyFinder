using Microsoft.JSInterop;
using MonkeyFinder.Shared.Models.Map;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class WebMapService : IMapService
{
    private readonly IJSRuntime _jsRuntime;

    public WebMapService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task OpenAsync(double latitude, double longitude, MapLaunchOptions options)
    {
        await _jsRuntime.InvokeVoidAsync("openMap", latitude, longitude);
    }
}
