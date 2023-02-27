using AutoMapper;
using AutoMapper.QueryableExtensions;
using Collections.ApplicationCore.Models;
using Collections.Infrastructure.Data.Contexts;
using Collections.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Collections.Infrastructure.Data.Repositories;

public class ItemSearchRepository : IItemSearchRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public ItemSearchRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TProjectTo>> SearchProjectedAsync<TProjectTo>(string searchTerm)
    {
        searchTerm = searchTerm.Trim().Replace(" ", "<->");
        var query = $"{searchTerm}:*";
        var items = _dbContext.Items.AsNoTracking()
            .Where(
            i =>
                EF.Functions.ToTsVector(i.Title).Matches(query) ||
                EF.Functions.ToTsVector(i.UserCollection.Title + " " + i.UserCollection.Description)
                    .Matches(query) ||
                EF.Functions
                    .ToTsVector(i.UserCollection.UserProfile.FirstName + " " + i.UserCollection.UserProfile.LastName)
                    .Matches(query) ||
                i.Comments.Any(c => EF.Functions.ToTsVector(c.Body).Matches(query)) ||
                i.ExtraFields.Any(e => EF.Functions.ToTsVector(e.Value).Matches(query)))
            .Take(10);
        return await items.ProjectTo<TProjectTo>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task AddAsync(Item item, IEnumerable<string> tags)
    {
        foreach (var tag in tags)
        {
            if (int.TryParse(tag, out var tagId))
            {
                item.Tags.Add(await _dbContext.Tags.FirstAsync(t => t.Id == tagId));
                continue;
            }
            item.Tags.Add(new Tag(tag));
        }
        await _dbContext.Items.AddAsync(item);
        await _dbContext.SaveChangesAsync();
    }
}