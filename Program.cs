using Microsoft.AspNetCore.OpenApi;
using ai_agent_backend.Extensions;
using ai_agent_backend.Routing;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServices();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapWebApplicationRoutes();
app.MapOpenApi();

app.Run();
