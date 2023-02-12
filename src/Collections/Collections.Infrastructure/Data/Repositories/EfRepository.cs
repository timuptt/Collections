using AutoMapper;
using Collections.Infrastructure.Data.Contexts;
using Collections.Shared.Interfaces;

namespace Collections.Infrastructure.Data.Repositories;

public class EfRepository<T> : ApplicationRepository<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public EfRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
}