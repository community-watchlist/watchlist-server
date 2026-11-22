using Application.Common.Interfaces.Integrations.Anime;
using Application.Episodes.Dtos;
using Application.Titles.Dtos;
using Infrastructure.Integrations.Jikan.Clients;
using Infrastructure.Integrations.Jikan.Models.Responses;
using LanguageExt;

namespace Infrastructure.Integrations.Jikan;

public class JikanAnimeProvider(AnimeHttpClient animeHttpClient) : IAnimeProvider
{
    private const string Provider = "jikan-edge";
    
    public async Task<IReadOnlyList<TitleMetadata>> GetCurrentSeason(CancellationToken cancellationToken)
    {
        var response = await animeHttpClient.GetCurrentSeason(cancellationToken);
        
        if (response == null)
            return [];
        
        return response.Data.Select(AnimeSeasonApiResponseData.ToMetadata).ToList();
    }

    public async Task<IReadOnlyList<TitleMetadata>> GetAnimeBySeason(string year, string season, CancellationToken cancellationToken)
    {
        var response = await animeHttpClient.GetAnimeBySeason(year, season, cancellationToken);
        
        if (response == null)
            return [];
        
        return response.Data.Select(AnimeSeasonApiResponseData.ToMetadata).ToList();
    }

    public async Task<IReadOnlyList<TitleMetadata>> GetTopRated(CancellationToken cancellationToken)
    {
        var response = await animeHttpClient.GetTopRated(cancellationToken);
        
        if (response == null)
            return [];
        
        return response.Data.Select(AnimeTopApiResponseData.ToMetadata).ToList();
    }

    public async Task<IReadOnlyList<TitleMetadata>> GetUpcomingSeason(CancellationToken cancellationToken)
    {
        var response = await animeHttpClient.GetUpcomingSeason(cancellationToken);
        
        if (response == null)
            return [];
        
        return response.Data.Select(AnimeSeasonApiResponseData.ToMetadata).ToList();
    }

    public async Task<IReadOnlyList<TitleMetadata>> GetBySearch(string query, CancellationToken cancellationToken)
    {
        var response = await animeHttpClient.GetBySearch(query, cancellationToken);
        
        if (response == null)
            return [];
        
        return response.Data.Select(AnimeSearchApiResponseData.ToMetadata).ToList();
    }

    public async Task<Option<TitleDetailsMetadata>> GetAnimeById(string animeId, string provider, CancellationToken cancellationToken)
    {
        VerifyProvider(provider);
        var response = await animeHttpClient.GetAnimeById(animeId, cancellationToken);

        if (response == null)
            return null;

        return AnimeDetailsApiResponseData.ToMetadata(response.Data);
    }

    public async Task<IReadOnlyList<EpisodeMetadata>> GetEpisodesByAnimeId(string animeId, string provider, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Option<EpisodeMetadata>> GetEpisodeByPosition(string animeId, string provider, string position, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Option<EpisodeMetadata>> GetEpisodeById(string episodeId, string provider, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private void VerifyProvider(string provider)
    {
        if (provider != Provider)
        { // TODO: add custom exception
            throw new NotImplementedException($"Provider {provider} is not supported!");
        } 
    }
}