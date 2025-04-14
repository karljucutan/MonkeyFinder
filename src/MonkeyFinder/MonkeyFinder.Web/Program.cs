using Microsoft.FluentUI.AspNetCore.Components;
using MonkeyFinder.Shared.Extensions;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Shared.States;
using MonkeyFinder.Web.ApiEndpoints;
using MonkeyFinder.Web.Client.Services;
using MonkeyFinder.Web.Components;
using Scalar.AspNetCore;
using FormFactor = MonkeyFinder.Web.Services.FormFactor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddFluentUIComponents();

// Add device-specific services used by the MonkeyFinder.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Add server-side services implementation while WASM is not yet available.
builder.Services.AddSharedServices();

// Add Navigation Service for Web implementation
builder.Services.AddScoped<INavigationService, WebNavigationService>();
//builder.Services.AddScoped<INavigationService>(sp =>
//new WebNavigationService(sp.GetRequiredService<NavigationManager>()));

builder.Services.AddScoped<IConnectivityService, WebConnectivityService>();
builder.Services.AddScoped<IGeolocationService, WebGeolocationService>();
builder.Services.AddScoped<IMapService, WebMapService>();
builder.Services.AddScoped<ThemeState>();
builder.Services.AddScoped<MonkeyRatingState>();

var app = builder.Build();

// Open API documentation and Scalar API references
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseStaticFiles();
app.MapStaticAssets();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MonkeyFinder.Shared._Imports).Assembly,
        typeof(MonkeyFinder.Web.Client._Imports).Assembly);

app.MapMonkeysEndpoints();

app.Run();
