using Application.Titles.Dtos;
using Domain.Titles;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record AnimeSeasonApiResponseData(
    List<AnimeData> Data,
    ResponseMeta Meta
)
{
    public static TitleMetadata ToMetadata(AnimeData response)
        => new TitleMetadata(
            Type: TitleType.Anime,
            Provider: "jikan-edge",
            ExternalId: response.MalId.ToString(),
            OriginalTitle: response.Title,
            Overview: null,
            Poster: new TitlePosterMetadata(
                OriginalFilename: response.ImageUrl.Split('/').Last().Split('.').First(),
                Url: response.ImageUrl),
            TitleReleaseStatus: null,
            FetchedAt: DateTime.UtcNow,
            Rating: null,
            OriginalLanguage: null,
            ExternalScore: Single.TryParse(response.Score.ToString(), out float result) ? result : null,
            ExternalScoreCount: null,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.StartDate, "YYYYMMDD"),
            Episodes: response.Episodes,
            MediaType: response.Type);
}

public record AnimeData(
    int MalId,
    string Title,
    string ImageUrl,
    double? Score,
    string Type,
    int? Episodes,
    string? StartDate,
    int? Members,
    bool? Continuing
);