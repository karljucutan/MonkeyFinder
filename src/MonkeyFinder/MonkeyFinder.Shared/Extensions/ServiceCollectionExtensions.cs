using Microsoft.Extensions.DependencyInjection;
using MonkeyFinder.Shared.Services;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Shared.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        // Register services related to MonkeyFinder.Shared
        services.AddSingleton<IMonkeyService, MonkeyService>();

        return services;
    }
}
