using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Data.Repositories;

public abstract class ApplicationRepository<T> : RepositoryBase<T> where T : class, IAggregateRoot
{
    private readonly IMapper _mapper;
    private readonly DbContext _dbContext;

    protected ApplicationRepository(DbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    protected ApplicationRepository(DbContext dbContext, ISpecificationEvaluator specificationEvaluator)
        : base(dbContext, specificationEvaluator)
    {
        _dbContext = dbContext;
    }

    protected ApplicationRepository(DbContext dbContext,
        IMapper mapper)
        : base(dbContext)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<List<TProjectTo>> ListProjectedAsync<TProjectTo>(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return await SpecificationEvaluator.Default
            .GetQuery(_dbContext.Set<T>()
                .AsNoTracking()
                .AsQueryable(), specification)
            .ProjectTo<TProjectTo>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<TProjectTo>> ListProjectedAsync<TProjectTo>(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>()
            .AsNoTracking()
            .ProjectTo<TProjectTo>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public async Task<TProjectTo> GetBySpecProjectedAsync<TProjectTo>(ISpecification<T> specification,
        CancellationToken cancellationToken = default) => 
        await ApplySpecification(specification)
            .AsNoTracking()
            .ProjectTo<TProjectTo>(_mapper.ConfigurationProvider)
            .FirstAsync(cancellationToken);
}