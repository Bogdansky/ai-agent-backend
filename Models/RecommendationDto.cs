namespace ai_agent_backend.Models;

public record RecommendationDto
{
    public required string Genre { get; init; }
    public required string Mood { get; init; }
    public required string Language { get; init; }
}