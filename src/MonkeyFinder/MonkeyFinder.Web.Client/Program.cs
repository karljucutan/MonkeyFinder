using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Web.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IMonkeyService, ClientMonkeyService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

// Add device-specific services used by the MonkeyFinder.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Add shared services that is in MonkeyFinder.Shared project
//builder.Services.AddSharedServices(); // There is a CORS issue when the CSR calls https://montemagno.com/monkeys.json (strict-origin-when-cross-origin) Calling it should be done in the Server acting as a proxy and intermediary between the frontend and other apis/systems.
MonkeyContext.Default.Options.PropertyNameCaseInsensitive = true;
await builder.Build().RunAsync();
