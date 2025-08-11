using System.Text.Json;
using ai_agent_backend.Models;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.RequestModels;

namespace ai_agent_backend.Services;

public class RecommendationService(IOpenAIService aIService) : IRecommendationService
{
    public async Task<RecommendationResponse> MakeRecommendationsAsync(RecommendationDto recommendation)
    {
        var userPrompts = string.Format(
            PromptStorage.MovieRecommendationUserPrompt,
            recommendation.Mood,
            recommendation.Language,
            recommendation.Genre);

        var request = new ChatCompletionCreateRequest
        {
            Model = OpenAI.ObjectModels.Models.Gpt_4o_mini_2024_07_18,
            Messages =
            [
                ChatMessage.FromSystem(PromptStorage.MovieRecommendationSystemPrompt),
                ChatMessage.FromUser(userPrompts)
            ],
            MaxTokens = 1024,
            Temperature = 0.4f,
        };

        var completionResult = await aIService.ChatCompletion.CreateCompletion(request);

        var recommendations = completionResult?.Choices.FirstOrDefault()?.Message.Content;
        var emptyResponse = new RecommendationResponse
        {
            Recommendations = []
        };

        return recommendations is null
            ? emptyResponse
            : JsonSerializer.Deserialize<RecommendationResponse>(recommendations, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            }) ?? emptyResponse;
    }
}