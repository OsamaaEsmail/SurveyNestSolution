using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SurveyNest.Application.Extensions;
using SurveyNest.BuildingBlocks.SharedExtensions;
using System.Threading.RateLimiting;

namespace SurveyNest.BuildingBlocks;

public static class BuildingBlocksDependencyInjection
{
    public static IServiceCollection AddBuildingBlocksService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAddRateLimiterConfig();
        services.AddCorsConfig(configuration);
        services.AddHealthChecksConfig(configuration);
        return services;
    }

    //==================================Private Methods======================================//
    private static IServiceCollection AddAddRateLimiterConfig(this IServiceCollection services)
    {
        services.AddRateLimiter(rateLimiterOptions =>
        {
            rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            // كل IP عنده Counter منفصل
            rateLimiterOptions.AddPolicy(RateLimiters.IpLimiter, httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        Window = TimeSpan.FromSeconds(10),
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        QueueLimit = 5
                    }
                )
            );

            // كل User عنده Counter منفصل
            rateLimiterOptions.AddPolicy(RateLimiters.UserLimiter, httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.User.GetUserId(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 5,
                        Window = TimeSpan.FromSeconds(6),
                        QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                        QueueLimit = 0
                    }
                )
            );

            // للعمليات التقيلة
            rateLimiterOptions.AddConcurrencyLimiter(RateLimiters.ConcurrencyLimiter, options =>
            {
                options.PermitLimit = 1000;
                options.QueueLimit = 100;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
            });
        });

        return services;
    }


    private static IServiceCollection AddCorsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>()!);
            });
        });
        return services;
    }

    private static IServiceCollection AddHealthChecksConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHealthChecks()
            .AddSqlServer(
                connectionString: configuration.GetConnectionString("DefaultConnection")!,
                name: "Database",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["db", "sql"]
            );

        return services;
    }
}