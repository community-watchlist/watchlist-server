using Application.Common.Interfaces.Queries.Titles;
using Application.Common.Interfaces.Repositories.Titles;
using Domain.Titles;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Titles;

public class TitleRepository(ApplicationDbContext context) : ITitleRepository, ITitleQueries
{
    public async Task<IReadOnlyList<Title>> GetAll(TitleType? type, CancellationToken cancellationToken)
    {
        return await context.Titles
            .AsNoTracking()
            .Where(x => type == null || x.Type.Equals(type))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Title>> GetAllBySearch(string query, TitleType? type, CancellationToken cancellationToken)
    {

        return await context.Titles
            .AsNoTracking()
            .Where(x => 
                x.OriginalTitle.ToLower().Contains(query.Trim().ToLower()) 
                && type == null || x.Type.Equals(type))
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Title>> GetFiltered(
        TitleType? type,
        string? title,
        string? overview,
        TitleReleaseStatus? releaseStatus,
        DateTime? createdAtFrom, 
        DateTime? createdAtTo, 
        CancellationToken cancellationToken)
    {
        var titles = context.Titles.AsQueryable();
        
        if (type != null)
        {
            titles = titles.Where(x => x.Type.Equals(type));
        }

        if (!String.IsNullOrWhiteSpace(title))
        {
            titles = titles.Where(x => x.OriginalTitle.ToLower().Contains(title.ToLower()));
        }

        if (!String.IsNullOrWhiteSpace(overview))
        {
            titles = titles.Where(x => x.Overview != null && x.Overview.ToLower().Contains(overview.ToLower()));
        }

        if (releaseStatus != null)
        {
            titles = titles.Where(x => x.TitleReleaseStatus.Equals(releaseStatus));
        }

        if (createdAtFrom != null)
        {
            titles = titles.Where(x => x.CreatedAt >= createdAtFrom);
        }

        if (createdAtTo != null)
        {
            titles = titles.Where(x => x.CreatedAt <= createdAtTo);
        }
        
        return await titles.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Option<Title>> GetById(TitleId titleId, TitleType? type, CancellationToken cancellationToken)
    {
        var entity = await context.Titles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => 
                x.Id == titleId 
                && type == null || x.Type.Equals(type), cancellationToken);
        return entity ?? Option<Title>.None;
    }

    public async Task<Option<Title>> GetByIdWithDetails(TitleId titleId, TitleType? type, CancellationToken cancellationToken)
    {
        var entity = await context.Titles
            .AsNoTracking()
            .Include(x => x.TitleGenres)
                .ThenInclude(x => x.Genre)
            .Include(x => x.Properties)
            .FirstOrDefaultAsync(x => 
                x.Id == titleId 
                && type == null || x.Type.Equals(type), cancellationToken);
        return entity ?? Option<Title>.None;
    }

    public async Task<Option<Title>> GetByExternalId(string externalId, string provider, CancellationToken cancellationToken)
    {
        var entity = await context.Titles
            .AsNoTracking()
            .FirstOrDefaultAsync(x => 
                x.ExternalId.Equals(externalId) 
                && x.Provider.Equals(provider), cancellationToken);
        return entity ?? Option<Title>.None;
    }

    public async Task<Title> Add(Title title, CancellationToken cancellationToken)
    {
        await context.Titles.AddAsync(title, cancellationToken);
        return title;
    }

    public async Task<Title> Update(Title title, CancellationToken cancellationToken)
    {
        context.Titles.Update(title);
        return title;
    }

    public async Task Delete(Title title, CancellationToken cancellationToken)
    {
        context.Titles.Remove(title);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}