using System.Net.Http.Json;
using Infrastructure.Integrations.Jikan.Models.Responses;

namespace Infrastructure.Integrations.Jikan.Clients;

public class AnimeHttpClient(HttpClient httpClient)
{
    public async Task<AnimeSeasonApiResponseData?> GetCurrentSeason(CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync("seasons/now", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSeasonApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeSeasonApiResponseData?> GetAnimeBySeason(string year, string season, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"seasons/{year}/{season}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSeasonApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeTopApiResponseData?> GetTopRated(CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync("top/anime", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeTopApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeSeasonApiResponseData?> GetUpcomingSeason(CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync("seasons/upcoming", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSeasonApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeSearchApiResponseData?> GetBySearch(string query, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"anime?q={query}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSearchApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeDetailsApiResponseData?> GetAnimeById(string id, CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync($"anime/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeDetailsApiResponseData>(cancellationToken).Result;
    }
}