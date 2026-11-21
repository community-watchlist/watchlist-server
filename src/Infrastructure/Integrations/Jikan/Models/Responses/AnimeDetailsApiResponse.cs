using Application.Titles.Dtos;
using Domain.Titles;
using Domain.Titles.Attributes;
using Infrastructure.Integrations.Jikan.Mappings;

namespace Infrastructure.Integrations.Jikan.Models.Responses;

public record AnimeDetailsApiResponse(
    AnimeData Data,
    ResponseMeta Meta
)
{
    public static TitleDetailsMetadata ToMetadata(AnimeDetailsApiResponse response)
        => new(
            Type: TitleType.Anime,
            Provider: "jikan-edge",
            ExternalId: response.Data.MalId.ToString(),
            OriginalTitle: response.Data.Title,
            Overview: response.Data.Synopsis,
            TitleReleaseStatus: AnimeReleaseStatusMapper.ToDomainModel(response.Data.Status),
            FetchedAt: DateTime.UtcNow,
            Rating: AnimeRatingMapper.ToDomainModel(response.Data.Rating),
            BackdropImageUrl: null,
            OriginalLanguage: null,
            ExternalScore: Convert.ToSingle(response.Data.Score),
            ExternalScoreCount: response.Data.ScoredBy,
            ReleaseDate: AnimeDateMapper.ToDateTime(response.Data.Aired.From),
            ExternalPopularity: response.Data.Popularity,
            Runtime: AnimeDurationMapper.ToMinutes(response.Data.Duration, response.Data.Episodes),
            Episodes: response.Data.Episodes,
            MediaType: response.Data.Type,
            AverageRuntime: AnimeDurationMapper.ToMinutes(response.Data.Duration, response.Data.Episodes),
            Aired: response.Data.Aired.From is null && response.Data.Aired.To is null
                ? null
                : AiredData.New(
                    AnimeDateMapper.ToDateTime(response.Data.Aired.From),
                    AnimeDateMapper.ToDateTime(response.Data.Aired.To)),
            Broadcast: AnimeDateMapper.ToWeekDay(response.Data.Broadcast.Day) is { } time 
                ? BroadcastData.New(time, response.Data.Broadcast.Time)
                : null,
            AlternativeLinks: [Link.New("MyAnimeList", response.Data.Url)],
            SocialLinks: response.Data.ExternalLinks.Select(x => Link.New(x.Name, x.Url)).ToList(),
            StreamingLinks: response.Data.ExternalLinks.Select(x => Link.New(x.Name, x.Url)).ToList(),
            Relations: response.Data.Relations.Select(x 
                => Relation.New(AnimeRelationMapper.ToDomainModel(x.Relation), x.Title, x.MalId.ToString())).ToList(),
            Genres: response.Data.Genres.Select(x => new GenreMetadata(x.MalId.ToString(), x.Name)).ToList());
};

public record AnimeData(
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