using Ardalis.Specification;
using Collections.Infrastructure.Data.Repositories.Options;
using Collections.Shared.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Collections.Infrastructure.Data.Repositories;

public class CachedRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
{
    private readonly IMemoryCache _cache;
    private readonly ILogger<CachedRepository<T>> _logger;
    private readonly EfRepository<T> _sourceRepository;
    private readonly MemoryCacheEntryOptions _cacheOptions;

    public CachedRepository(IMemoryCache cache,
        ILogger<CachedRepository<T>> logger,
        EfRepository<T> sourceRepository, IOptions<CachingOptions> cachingOptions)
    {
        _cache = cache;
        _logger = logger;
        _sourceRepository = sourceRepository;
        _cacheOptions =
            new MemoryCacheEntryOptions().SetAbsoluteExpiration(
                relative: TimeSpan.FromSeconds(cachingOptions.Value.HotCachingInterval));

    }
    
    public Task<T?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = new CancellationToken()) where TId : notnull
    {
        return _sourceRepository.GetByIdAsync(id, cancellationToken);
    }

    public Task<T?> GetBySpecAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        if(specification.CacheEnabled)
        {
            var key = $"{specification.CacheKey}-GetBySpecAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
            });
        }
        return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
    }

    public Task<TResult?> GetBySpecAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.GetBySpecAsync(specification, cancellationToken);
    }

    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    }

    public Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> specification,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.FirstOrDefaultAsync(specification, cancellationToken);
    }

    public Task<T?> SingleOrDefaultAsync(ISingleResultSpecification<T> specification,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.SingleOrDefaultAsync(specification, cancellationToken);
    }

    public Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<T, TResult> specification,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.SingleOrDefaultAsync(specification, cancellationToken);
    }

    public Task<List<T>> ListAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.ListAsync(cancellationToken);
    }

    public Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        if (specification.CacheEnabled)
        {
            var key = $"{specification.CacheKey}-ListAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.ListAsync(specification, cancellationToken);
            })!;
        }
        return _sourceRepository.ListAsync(specification, cancellationToken);
    }

    public Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.ListAsync(specification, cancellationToken);
    }

    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        if (specification.CacheEnabled)
        {
            var key = $"{specification.CacheKey}-CountAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.CountAsync(specification, cancellationToken);
            })!;
        }

        return _sourceRepository.CountAsync(specification, cancellationToken);
    }

    public Task<int> CountAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.CountAsync();
    }

    public Task<bool> AnyAsync(ISpecification<T> specification, CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.AnyAsync(specification);
    }

    public Task<bool> AnyAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return _sourceRepository.AnyAsync();
    }

    public Task<List<TProjectTo>> ListProjectedAsync<TProjectTo>(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            var key = $"{specification.CacheKey}-ListProjectedAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.ListProjectedAsync<TProjectTo>(specification, cancellationToken);
            })!;
        }
        return _sourceRepository.ListProjectedAsync<TProjectTo>(specification, cancellationToken);
    }

    public Task<TProjectTo> GetBySpecProjectedAsync<TProjectTo>(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        if (specification.CacheEnabled)
        {
            var key = $"{specification.CacheKey}-GetBySpecProjectedAsync";
            _logger.LogInformation("Checking cache for " + key);
            return _cache.GetOrCreate(key, entry =>
            {
                entry.SetOptions(_cacheOptions);
                _logger.LogWarning("Fetching source data for " + key);
                return _sourceRepository.GetBySpecProjectedAsync<TProjectTo>(specification, cancellationToken);
            })!;
        }
        return _sourceRepository.GetBySpecProjectedAsync<TProjectTo>(specification, cancellationToken);
    }
    
    public Task<List<TProjectTo>> ListProjectedAsync<TProjectTo>(CancellationToken cancellationToken = default)
    {
        return _sourceRepository.ListProjectedAsync<TProjectTo>(cancellationToken);
    }
}