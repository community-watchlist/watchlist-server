using Application.Episodes.Dtos;
using Domain.Episodes.Attributes;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record EpisodeApiResponseData(
    List<EpisodeApiData> Data,
    ResponseMetaWithPagination Meta
)
{
    public static EpisodeMetadata ToMetadata(EpisodeApiData response, string animeId)
        => new EpisodeMetadata(
            Provider: "jikan-edge",
            ExternalId: $"{animeId}@{response.Number}",
            ExternalTitleId: animeId,
            OriginalTitle: response.Title,
            Overview: null,
            Position: response.Number,
            FetchedAt: DateTime.UtcNow,
            Runtime: null,
            PosterUrl: null,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.Aired),
            ExternalScore: Single.TryParse(response.Score.ToString(), out float result) ? result : null,
            ExternalScoreCount: null,
            AlternativeLinks: response.Url != null 
                ? [Link.New("MyAnimeList", response.Url)] 
                : null,
            StreamingLinks: null
        );
}

public record EpisodeApiData(
    int Number,
    string Title,
    string? TitleJapanese,
    string? Url,
    string? Aired,
    double? Score,
    int? ForumReplies,
    bool Filler,
    bool Recap
);