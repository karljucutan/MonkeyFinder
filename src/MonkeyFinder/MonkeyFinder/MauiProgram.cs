using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using MonkeyFinder.Services;
using MonkeyFinder.Shared.Extensions;
using MonkeyFinder.Shared.Services;

namespace MonkeyFinder;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the MonkeyFinder.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        // Add shared services that is in MonkeyFinder.Shared project
        builder.Services.AddSharedServices();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
