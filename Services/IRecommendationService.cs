using ai_agent_backend.Models;

namespace ai_agent_backend.Services;

public interface IRecommendationService
{
    Task<RecommendationResponse> MakeRecommendationsAsync(RecommendationDto recommendation);
}