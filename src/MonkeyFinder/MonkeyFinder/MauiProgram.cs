﻿using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using MonkeyFinder.Services;
using MonkeyFinder.Shared.Extensions;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Shared.States;

namespace MonkeyFinder;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Add device-specific services used by the MonkeyFinder.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        // Add shared services that is in MonkeyFinder.Shared project
        builder.Services.AddSharedServices();

        // Add Navigation Service for MAUI implementation
        builder.Services.AddSingleton<INavigationService, MauiNavigationService>();

        builder.Services.AddSingleton<IConnectivityService, MauiConnectivityService>();

        builder.Services.AddSingleton<IGeolocation>(sp => Geolocation.Default);

        builder.Services.AddSingleton<IGeolocationService, MauiGeolocationService>();

        builder.Services.AddSingleton<IMap>(sp => Map.Default);

        builder.Services.AddSingleton<IMapService, MauiMapService>();

        builder.Services.AddSingleton<ThemeState>();

        builder.Services.AddSingleton<MonkeyRatingState>();

        builder.Services.AddMauiBlazorWebView();
        builder.Services.AddFluentUIComponents();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
