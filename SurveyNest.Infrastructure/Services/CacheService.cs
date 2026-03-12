using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using SurveyNest.Application.Interfaces;

namespace SurveyNest.Infrastructure.Services;

public class CacheService(HybridCache hybridCache, ILogger<CacheService> logger) : ICacheService
{
    private readonly HybridCache _hybridCache = hybridCache;
    private readonly ILogger<CacheService> _logger = logger;

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        _logger.LogInformation("Get value from cache with key: {CacheKey}", key);

        return await _hybridCache.GetOrCreateAsync<T>(
            key,
            _ => ValueTask.FromResult<T>(null!),
            cancellationToken: cancellationToken
        );
    }

    public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
    {
        _logger.LogInformation("Set cache with key: {CacheKey}", key);
        await _hybridCache.SetAsync(key, value, cancellationToken: cancellationToken);
    }

    public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Remove cache with key: {CacheKey}", key);
        await _hybridCache.RemoveAsync(key, cancellationToken);
    }
}