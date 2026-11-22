using Application.Titles.Dtos;
using LanguageExt;

namespace Application.Common.Interfaces.Integrations.Anime;

public interface IAnimeProvider
{ // TODO: episodes, all metadata!
    Task<IReadOnlyList<TitleMetadata>> GetCurrentSeason(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetAnimeBySeason(string year, string season, CancellationToken cancellationToken);  
    Task<IReadOnlyList<TitleMetadata>> GetTopRated(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetUpcomingSeason(CancellationToken cancellationToken);
    Task<IReadOnlyList<TitleMetadata>> GetBySearch(string query, CancellationToken cancellationToken);
    Task<Option<TitleDetailsMetadata>> GetAnimeById(string animeId, string provider, CancellationToken cancellationToken);
}