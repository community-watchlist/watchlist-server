using Domain.Episodes;
using Domain.Titles;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Episodes;

public interface IEpisodeQueries
{
    Task<IReadOnlyList<Episode>> GetAllByTitleId(TitleId titleId, CancellationToken cancellationToken);
    Task<Option<Episode>> GetByTitleIdAndPosition(TitleId titleId, int position, CancellationToken cancellationToken);
    Task<Option<Episode>> GetById(EpisodeId episodeId, CancellationToken cancellationToken);
    Task<Option<Episode>> GetEpisodeBySlug(string slug, CancellationToken cancellationToken);   
    Task<Option<Episode>> GetByIdWithDetails(EpisodeId episodeId, CancellationToken cancellationToken);
}