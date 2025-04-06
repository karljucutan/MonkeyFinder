using Microsoft.AspNetCore.Components;

namespace MonkeyFinder.Shared.Extensions;

public static class RendererInfoExtensions
{
    private const string Static = "Static";
    private const string WebView = "WebView";
    private const string WebAssembly = "WebAssembly";

    public static bool IsClientSideRendering(this RendererInfo rendererInfo)
    {
        return string.Equals(rendererInfo.Name, WebView, StringComparison.OrdinalIgnoreCase)
            || string.Equals(rendererInfo.Name, WebAssembly, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsStaticRendering(this RendererInfo rendererInfo)
    {
        return string.Equals(rendererInfo.Name, Static, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsWebViewRendering(this RendererInfo rendererInfo)
    {
        return string.Equals(rendererInfo.Name, WebView, StringComparison.OrdinalIgnoreCase);
    }
}
