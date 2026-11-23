using Application.Titles.Dtos;
using Domain.Titles;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record AnimeTopApiResponseData(
    List<AnimeTopData> Data,
    ResponseMetaWithPagination Meta
)
{
    public static TitleMetadata ToMetadata(AnimeTopData response)
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
            ReleaseDate: AnimeDateMapper.ToDateTime(response.StartDate?.Split('-')[0], "MMM YYYY"),
            Episodes: response.Episodes,
            MediaType: response.Type);
}

public record AnimeTopData(
    int MalId,
    string Title,
    string ImageUrl,
    double? Score,
    string Type,
    int? Episodes,
    string? StartDate,
    int? Members
);