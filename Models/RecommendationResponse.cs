namespace ai_agent_backend.Models;

public record RecommendationResponse
{
    public required IReadOnlyCollection<MovieRecommendation> Recommendations { get; init; }
}

public record MovieRecommendation
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required int ReleaseYear { get; init; }
    public required string PosterLink { get; init; }
}