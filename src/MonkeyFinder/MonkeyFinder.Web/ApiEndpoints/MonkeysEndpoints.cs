namespace MonkeyFinder.Web.ApiEndpoints;

public static class MonkeysEndpoints
{
    public static void MapMonkeysEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/monkeys");

        group.MapGet("/", () => Results.Ok("Retrieve all monkeys"))
            .WithName("GetAllMonkeys")
            .WithOpenApi();
    }
}
