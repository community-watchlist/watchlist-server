using Infrastructure.Integrations.Jikan.Clients;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Integrations;

public static class ConfigureIntegrationServices
{
    public static void AddIntegrationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClients(configuration);
    }

    private static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient<JikanAnimeHttpClient>((serviceProvider, httpClient) =>
        {
            var baseUrl = configuration.GetSection("Integrations:JikanApi:BaseUrl").Value;
            
            httpClient.BaseAddress = new Uri($"{baseUrl!.TrimEnd('/')}/anime/");
        });
        
        services.AddHttpClient<JikanSeasonsHttpClient>((serviceProvider, httpClient) =>
        {
            var baseUrl = configuration.GetSection("Integrations:JikanApi:BaseUrl").Value;
            
            httpClient.BaseAddress = new Uri($"{baseUrl!.TrimEnd('/')}/seasons/");
        });
        
        services.AddHttpClient<JikanTopHttpClient>((serviceProvider, httpClient) =>
        {
            var baseUrl = configuration.GetSection("Integrations:JikanApi:BaseUrl").Value;
            
            httpClient.BaseAddress = new Uri($"{baseUrl!.TrimEnd('/')}/top/");
        });
    }
}