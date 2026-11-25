using System.Net.Http.Json;
using Infrastructure.Integrations.Jikan.Models.Responses;

namespace Infrastructure.Integrations.Jikan.Clients;

public class JikanAnimeHttpClient(HttpClient httpClient)
{
    public async Task<AnimeSearchApiResponseData?> GetBySearch(string query, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"?q={query}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSearchApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeDetailsApiResponseData?> GetAnimeById(string id, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeDetailsApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<EpisodeApiResponseData?> GetEpisodesByAnimeId(string animeId, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"{animeId}/episodes", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<EpisodeApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<EpisodeDetailsApiResponseData?> GetEpisodesByAnimeIdAndPosition(string animeId, string position, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"{animeId}/episodes/{position}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<EpisodeDetailsApiResponseData>(cancellationToken).Result;
    }
}