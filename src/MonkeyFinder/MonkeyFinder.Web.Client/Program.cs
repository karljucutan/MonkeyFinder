using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MonkeyFinder.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
