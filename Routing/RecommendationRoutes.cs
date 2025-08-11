using ai_agent_backend.Models;
using ai_agent_backend.Services;

namespace ai_agent_backend.Routing;

public static class RecommendationRoutes
{
    public static void MapRecommendationRoutes(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/recommendations", async (IRecommendationService recommendationService, RecommendationDto recommendation) =>
        {
            var recommendations = await recommendationService.MakeRecommendationsAsync(recommendation);
            return Results.Ok(recommendations);
        }).WithOpenApi();
    }
}