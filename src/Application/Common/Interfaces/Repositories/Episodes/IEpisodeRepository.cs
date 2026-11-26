using Domain.Episodes;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Episodes;

public interface IEpisodeRepository
{
    Task<Option<Episode>> GetById(EpisodeId episodeId, CancellationToken cancellationToken);
    Task<Option<Episode>> GetEpisodeBySlug(string slug, CancellationToken cancellationToken);
    Task<Option<Episode>> GetByExternalId(string externalId, string provider, CancellationToken cancellationToken);
    Task<Episode> Add(Episode episode, CancellationToken cancellationToken);
    Task<Episode> Update(Episode episode, CancellationToken cancellationToken);
    Task Delete(Episode episode, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}