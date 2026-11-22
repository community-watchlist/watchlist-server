using Application.Episodes.Dtos;
using Application.Titles.Dtos;
using LanguageExt;

namespace Application.Common.Interfaces.Integrations.Anime;

public interface IAnimeProvider
{
    Task<IReadOnlyList<TitleMetadata>> GetCurrentSeason(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetAnimeBySeason(string year, string season, CancellationToken cancellationToken);  
    Task<IReadOnlyList<TitleMetadata>> GetTopRated(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetUpcomingSeason(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetBySearch(string query, CancellationToken cancellationToken);
    Task<Option<TitleDetailsMetadata>> GetAnimeById(string animeId, string provider, CancellationToken cancellationToken);
    
    Task<IReadOnlyList<EpisodeMetadata>> GetEpisodesByAnimeId(string animeId, string provider, CancellationToken cancellationToken);
    Task<Option<EpisodeMetadata>> GetEpisodeByPosition(string animeId, string position, string provider, CancellationToken cancellationToken);
    Task<Option<EpisodeMetadata>> GetEpisodeById(string episodeId, string provider, CancellationToken cancellationToken);
}