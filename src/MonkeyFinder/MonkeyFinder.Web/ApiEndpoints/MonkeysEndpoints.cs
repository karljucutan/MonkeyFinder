using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.ApiEndpoints;

public static class MonkeysEndpoints
{
    public static void MapMonkeysEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/monkeys");

        group.MapGet("/", async (IMonkeyService monkeyService) => await monkeyService.GetMonkeysAsync())
            .WithName("GetAllMonkeys")
            .WithOpenApi();

        group.MapPost("/", async (IMonkeyService monkeyService, Monkey monkey) => await monkeyService.AddMonkeyAsync(monkey))
            .WithName("AddMonkey")
            .WithOpenApi();

        group.MapGet("/{name}", async (IMonkeyService monkeyService, string name) => await monkeyService.FindMonkeyByNameAsync(name))
            .WithName("GetMonkeyByName")
            .WithOpenApi();
    }
}
