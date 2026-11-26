using Application.Common.Interfaces.Queries.Episodes;
using Application.Common.Interfaces.Repositories.Episodes;
using Domain.Episodes;
using Domain.Episodes.Properties;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Episodes;

public class EpisodePropertiesRepository(ApplicationDbContext context) : IEpisodePropertiesRepository, IEpisodePropertiesQueries
{
    public async Task<Option<EpisodeProperties>> GetById(EpisodePropertiesId episodePropertiesId, CancellationToken cancellationToken)
    {
        var entity = await context.EpisodeProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == episodePropertiesId, cancellationToken);
        return entity ?? Option<EpisodeProperties>.None;
    }

    public async Task<Option<EpisodeProperties>> GetBySlug(string slug, CancellationToken cancellationToken)
    {
        var entity = await context.EpisodeProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug.Equals(slug), cancellationToken);
        return entity ?? Option<EpisodeProperties>.None;
    }
    
    public async Task<Option<EpisodeProperties>> GetByEpisodeId(EpisodeId episodeId, CancellationToken cancellationToken)
    {
        var entity = await context.EpisodeProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.EpisodeId == episodeId, cancellationToken);
        return entity ?? Option<EpisodeProperties>.None;
    }

    public async Task<EpisodeProperties> Add(EpisodeProperties episodeProperties, CancellationToken cancellationToken)
    {
        await context.EpisodeProperties.AddAsync(episodeProperties, cancellationToken);
        return episodeProperties;
    }

    public async Task<EpisodeProperties> Update(EpisodeProperties episodeProperties, CancellationToken cancellationToken)
    {
        context.EpisodeProperties.Update(episodeProperties);
        return episodeProperties;
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}