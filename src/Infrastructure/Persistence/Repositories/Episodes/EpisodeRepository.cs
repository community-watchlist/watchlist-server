using Application.Common.Interfaces.Queries.Episodes;
using Application.Common.Interfaces.Repositories.Episodes;
using Domain.Episodes;
using Domain.Titles;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Episodes;

public class EpisodeRepository(ApplicationDbContext context) : IEpisodeRepository, IEpisodeQueries
{
    public async Task<IReadOnlyList<Episode>> GetAllByTitleId(TitleId titleId, CancellationToken cancellationToken)
    {
        return await context.Episodes
            .AsNoTracking()
            .Where(x => x.TitleId == titleId)
            .ToListAsync(cancellationToken);
    }

    public async Task<Option<Episode>> GetByTitleIdAndPosition(TitleId titleId, int position, CancellationToken cancellationToken)
    {
        var entity = await context.Episodes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.TitleId == titleId && x.Position == position, cancellationToken);
        return entity ?? Option<Episode>.None;
    }

    public async Task<Option<Episode>> GetById(EpisodeId episodeId, CancellationToken cancellationToken)
    {
        var entity = await context.Episodes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == episodeId, cancellationToken);
        return entity ?? Option<Episode>.None;
    }

    public async Task<Option<Episode>> GetEpisodeBySlug(string slug, CancellationToken cancellationToken)
    {
        var entity = await context.Episodes
            .AsNoTracking()
            .Include(x => x.EpisodeProperties)
            .FirstOrDefaultAsync(x => x.EpisodeProperties!.Slug == slug, cancellationToken);
        return entity ?? Option<Episode>.None;
    }

    public async Task<Option<Episode>> GetByExternalId(string externalId, string provider, CancellationToken cancellationToken)
    {
        var entity = await context.Episodes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ExternalId == externalId && x.Provider == provider, cancellationToken);
        return entity ?? Option<Episode>.None;
    }

    public async Task<Option<Episode>> GetByIdWithDetails(EpisodeId episodeId, CancellationToken cancellationToken)
    {
        var entity = await context.Episodes
            .AsNoTracking()
            .Include(x => x.EpisodeProperties)
            .FirstOrDefaultAsync(x => x.Id == episodeId, cancellationToken);
        return entity ?? Option<Episode>.None;
    }

    public async Task<Episode> Add(Episode episode, CancellationToken cancellationToken)
    {
        context.Episodes.Add(episode);
        return episode;
    }

    public async Task<Episode> Update(Episode episode, CancellationToken cancellationToken)
    {
        context.Episodes.Update(episode);
        return episode;
    }

    public async Task Delete(Episode episode, CancellationToken cancellationToken)
    {
        context.Episodes.Remove(episode);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}