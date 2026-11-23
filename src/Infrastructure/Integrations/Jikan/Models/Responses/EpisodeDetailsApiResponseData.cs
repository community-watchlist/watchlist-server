using Application.Episodes.Dtos;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record EpisodeDetailsApiResponseData(
    EpisodeDetailsApiData Data,
    ResponseMeta Meta
)
{
    public static EpisodeMetadata ToMetadata(EpisodeDetailsApiData response)
        => new EpisodeMetadata(
            Provider: "jikan-edge",
            ExternalId: $"{response.MalId}-{response.Episode}",
            ExternalTitleId: response.MalId.ToString(),
            OriginalTitle: response.Title,
            Overview: response.Synopsis,
            Position: response.Episode,
            FetchedAt: DateTime.UtcNow,
            Runtime: AnimeDateMapper.ToMinutes(response.Duration, "HH:MM:SS"),
            PosterUrl: null,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.Aired?.Split('(').First()),
            ExternalScore: null,
            ExternalScoreCount: null,
            AlternativeLinks: null,
            StreamingLinks: null
        );
}

public record EpisodeDetailsApiData(
    int MalId,
    int Episode,
    string Title,
    string? TitleAlternative,
    string? Duration,
    string? Aired,
    string? Synopsis
);