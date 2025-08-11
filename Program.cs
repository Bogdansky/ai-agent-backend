using Microsoft.AspNetCore.OpenApi;
using ai_agent_backend.Extensions;
using ai_agent_backend.Routing;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();
builder.Services.AddOpenApi();

// TODO: Configure CORS policies properly for production
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable CORS middleware
app.UseCors();

app.MapWebApplicationRoutes();
app.MapOpenApi();

app.Run();
