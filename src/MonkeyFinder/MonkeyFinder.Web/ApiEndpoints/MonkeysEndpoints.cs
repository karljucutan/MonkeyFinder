using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.ApiEndpoints;

public static class MonkeysEndpoints
{
    public static void MapMonkeysEndpoints(this IEndpointRouteBuilder routes)
    {
        RouteGroupBuilder group = routes.MapGroup("/api/monkeys");

        group.MapGet("/", async (IMonkeyService monkeyService) => await monkeyService.GetMonkeysAsync())
            .WithName("GetAllMonkeys")
            .WithOpenApi();
    }
}
