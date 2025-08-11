namespace ai_agent_backend.Routing;

public static class WebApplicationRoutingExtensions
{
    public static void MapWebApplicationRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapRootRoutes();
        routes.MapRecommendationRoutes();
        // Add other route mappings here as needed
    }
}