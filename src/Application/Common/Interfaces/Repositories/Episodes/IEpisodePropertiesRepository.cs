using Domain.Episodes.Properties;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Episodes;

public interface IEpisodePropertiesRepository
{
    Task<Option<EpisodeProperties>> GetById(EpisodePropertiesId episodePropertiesId, CancellationToken cancellationToken);
    Task<Option<EpisodeProperties>> GetBySlug(string slug, CancellationToken cancellationToken);
    Task<EpisodeProperties> Add(EpisodeProperties episodeProperties, CancellationToken cancellationToken);
    Task<EpisodeProperties> Update(EpisodeProperties episodeProperties, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}