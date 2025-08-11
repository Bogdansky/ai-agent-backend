using ai_agent_backend.Services;
using OpenAI;
using OpenAI.Interfaces;
using OpenAI.Managers;

namespace ai_agent_backend.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddRecommendationService();
        services.AddOpenAIService();
        // Add other services here as needed
    }

    public static void AddOpenAIService(this IServiceCollection services)
    {
        services.AddScoped<IOpenAIService, OpenAIService>(provider => 
        {
            var apiKey = Environment.GetEnvironmentVariable("OpenAiApiKey");

            ArgumentNullException.ThrowIfNull(apiKey, "OpenAiApiKey is not configured.");

            return new OpenAIService(new OpenAiOptions
            {
                ApiKey = apiKey
            });
        });
    }

    public static void AddRecommendationService(this IServiceCollection services)
    {
        services.AddScoped<IRecommendationService, RecommendationService>();
    }
}