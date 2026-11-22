using Application.Titles.Dtos;
using Domain.Titles;
using Domain.Titles.Attributes;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record AnimeDetailsApiResponseData(
    AnimeDetailsData Data,
    ResponseMeta Meta
)
{
    public static TitleDetailsMetadata ToMetadata(AnimeDetailsData response)
        => new(
            Type: TitleType.Anime,
            Provider: "jikan-edge",
            ExternalId: response.MalId.ToString(),
            OriginalTitle: response.Title,
            Overview: response.Synopsis,
            Poster: new TitlePosterMetadata(
                OriginalFilename: response.ImageUrl.Split('/').Last().Split('.').First(),
                Url: response.ImageUrl),
            TitleReleaseStatus: AnimeReleaseStatusMapper.ToDomainModel(response.Status),
            FetchedAt: DateTime.UtcNow,
            Rating: AnimeRatingMapper.ToDomainModel(response.Rating),
            BackdropImageUrl: null,
            OriginalLanguage: null,
            ExternalScore: Convert.ToSingle(response.Score),
            ExternalScoreCount: response.ScoredBy,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.Aired.From),
            ExternalPopularity: response.Popularity,
            Runtime: AnimeDurationMapper.ToMinutes(response.Duration, response.Episodes),
            Episodes: response.Episodes,
            MediaType: response.Type,
            AverageRuntime: AnimeDurationMapper.ToMinutes(response.Duration, response.Episodes),
            Aired: response.Aired.From is null && response.Aired.To is null
                ? null
                : AiredData.New(
                    AnimeDateMapper.ToDateTime(response.Aired.From),
                    AnimeDateMapper.ToDateTime(response.Aired.To)),
            Broadcast: AnimeDateMapper.ToWeekDay(response.Broadcast.Day) is { } time 
                ? BroadcastData.New(time, response.Broadcast.Time)
                : null,
            AlternativeLinks: [Link.New("MyAnimeList", response.Url)],
            SocialLinks: response.ExternalLinks.Select(x => Link.New(x.Name, x.Url)).ToList(),
            StreamingLinks: response.ExternalLinks.Select(x => Link.New(x.Name, x.Url)).ToList(),
            Relations: response.Relations.Select(x 
                => Relation.New(AnimeRelationMapper.ToDomainModel(x.Relation), x.Title, x.MalId.ToString())).ToList(),
            Genres: response.Genres.Select(x => new GenreMetadata(x.MalId.ToString(), x.Name)).ToList());
}

public record AnimeDetailsData(
    int MalId,
    string Url,
    string Title,
    string? TitleEnglish,
    string? TitleJapanese,
    List<string> TitleSynonyms,
    string ImageUrl,
    AnimeImages Images,
    Trailer Trailer,
    string? Synopsis,
    string? Background,
    string Type,
    int? Episodes,
    string Status,
    bool Airing,
    Aired Aired,
    string? Season,
    int? Year,
    Broadcast Broadcast,
    List<Producer> Studios,
    List<Producer> Producers,
    List<Producer> Licensors,
    List<MalEntry> Genres,
    List<MalEntry> Themes,
    List<MalEntry> Demographics,
    string? Duration,
    string? Rating,
    double? Score,
    int? ScoredBy,
    int? Rank,
    int? Popularity,
    int? Members,
    int? Favorites,
    string? Source,
    List<AnimeRelation> Relations,
    List<ExternalLink> ExternalLinks,
    List<StreamingPlatform> Streaming,
    DateTime FetchedAt
);

public record AnimeImages(
    string Small,
    string Medium,
    string Large
);

public record Trailer(
    string? YoutubeId,
    string? Url,
    string? EmbedUrl
);

public record Aired(
    DateOnly? From,
    DateOnly? To,
    string? String
);

public record Broadcast(
    string? Day,
    string? Time,
    string? Timezone,
    string? String
);

public record Producer(
    int MalId,
    string Name,
    string Url
);

public record MalEntry(
    int MalId,
    string Name,
    string Url
);

public record AnimeRelation(
    string Relation,
    int MalId,
    string Type,
    string Title
);

public record ExternalLink(
    string Name,
    string Url
);

public record StreamingPlatform(
    string Name,
    string Url,
    bool Available
);

public record ResponseMeta(
    bool Cached,
    bool Stale,
    bool RefreshFailed,
    DateTime FetchedAt
);