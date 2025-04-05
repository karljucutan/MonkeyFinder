using MonkeyFinder.Shared.Extensions;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Web.ApiEndpoints;
using MonkeyFinder.Web.Components;
using MonkeyFinder.Web.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the MonkeyFinder.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Add server-side services implementation while WASM is not yet available.
builder.Services.AddSharedServices();

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

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MonkeyFinder.Shared._Imports).Assembly,
        typeof(MonkeyFinder.Web.Client._Imports).Assembly);

app.MapMonkeysEndpoints();

app.Run();
