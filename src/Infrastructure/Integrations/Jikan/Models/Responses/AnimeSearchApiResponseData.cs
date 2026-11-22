using Application.Titles.Dtos;
using Domain.Titles;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record AnimeSearchApiResponseData(
    List<AnimeSearchData> Data,
    ResponseMetaWithPagination Meta
)
{
    public static TitleMetadata ToMetadata(AnimeSearchData response)
        => new TitleMetadata(
            Type: TitleType.Anime,
            Provider: "jikan-edge",
            ExternalId: response.MalId.ToString(),
            OriginalTitle: response.Title,
            Overview: response.Synopsis,
            Poster: new TitlePosterMetadata(
                OriginalFilename: response.ImageUrl.Split('/').Last().Split('.').First(),
                Url: response.ImageUrl),
            TitleReleaseStatus: null,
            FetchedAt: DateTime.UtcNow,
            Rating: AnimeRatingMapper.ToDomainModel(response.Rating),
            OriginalLanguage: null,
            ExternalScore: Single.TryParse(response.Score.ToString(), out float result) ? result : null,
            ExternalScoreCount: null,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.StartDate, "YYYY-MM"),
            Episodes: response.Episodes,
            MediaType: response.Type);
}

public record AnimeSearchData(
    int MalId,
    string Url,
    string Title,
    string ImageUrl,
    string? Synopsis,
    string Type,
    double? Score,
    string? StartDate,
    string? EndDate,
    int? Members,
    int? Episodes,
    string? Rating
);