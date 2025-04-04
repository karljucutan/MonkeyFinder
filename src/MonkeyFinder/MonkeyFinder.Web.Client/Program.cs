using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MonkeyFinder.Shared.Extensions;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Shared.Services.Abstractions;
using MonkeyFinder.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MonkeyFinder.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Add shared services that is in MonkeyFinder.Shared project
//builder.Services.AddSharedServices(); // There is a CORS issue when the CSR calls https://montemagno.com/monkeys.json (strict-origin-when-cross-origin) Calling it should be done in the Server acting as a proxy and intermediary between the frontend and other apis/systems.

builder.Services.AddSingleton<IMonkeyService, MonkeyFinder.Web.Client.Services.MonkeyService>();

await builder.Build().RunAsync();
