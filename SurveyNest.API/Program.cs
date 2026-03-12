using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using SurveyNest.API;
using SurveyNest.Application;
using SurveyNest.BuildingBlocks;
using SurveyNest.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);
// DependencyInjection
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddBuildingBlocksService(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddApiServices();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();
        foreach (var description in descriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant()
            );
        }
    });
}

app.UseExceptionHandler();       // 1️
app.UseSerilogRequestLogging();  // 2
app.UseHttpsRedirection();       // 3
app.UseCors();                   // 4
app.UseRateLimiter();            // 5
app.UseAuthentication();         // 6
app.UseAuthorization();          // 7
app.MapControllers();            // 8

// HealthCheck Endpoints
app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapHealthChecks("/health/db", new HealthCheckOptions
{
    Predicate = x => x.Tags.Contains("db"),
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();