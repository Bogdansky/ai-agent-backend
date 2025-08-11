namespace ai_agent_backend.Routing;

public static class RootRoutes
{
    public static void MapRootRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/", () => "Hello World!").WithOpenApi();
        // Add other route mappings here as needed
    }
}