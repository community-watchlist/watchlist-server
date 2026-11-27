using Domain.Episodes;
using Domain.Episodes.Properties;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Episodes;

public interface IEpisodePropertiesQueries
{
    Task<Option<EpisodeProperties>> GetByEpisodeId(EpisodeId episodeId, CancellationToken cancellationToken);
}