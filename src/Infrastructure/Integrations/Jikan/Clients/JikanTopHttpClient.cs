using System.Net.Http.Json;
using Infrastructure.Integrations.Jikan.Models.Responses;

namespace Infrastructure.Integrations.Jikan.Clients;

public class JikanTopHttpClient(HttpClient httpClient)
{
    public async Task<AnimeTopApiResponseData?> GetTopRated(CancellationToken cancellationToken)
    {
        using var response = await httpClient.GetAsync("anime", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        return response.Content.ReadFromJsonAsync<AnimeTopApiResponseData>(cancellationToken).Result;
    }
}