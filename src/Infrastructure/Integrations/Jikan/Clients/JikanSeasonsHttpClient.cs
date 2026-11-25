using System.Net.Http.Json;
using Infrastructure.Integrations.Jikan.Models.Responses;

namespace Infrastructure.Integrations.Jikan.Clients;

public class JikanSeasonsHttpClient(HttpClient httpClient)
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
        using var response = await httpClient.GetAsync($"{year}/{season}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSeasonApiResponseData>(cancellationToken).Result;
    }
    
    public async Task<AnimeSeasonApiResponseData?> GetUpcomingSeason(CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync("upcoming", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeSeasonApiResponseData>(cancellationToken).Result;
    }
}