using Domain.Titles;
using Domain.Titles.Attributes;

namespace Application.Titles.Dtos;

public record TitleDetailsMetadata(
    TitleType Type,
    string Provider,
    string ExternalId,
    string OriginalTitle,
    string? Overview,
    TitlePosterMetadata? Poster,
    TitleReleaseStatus TitleReleaseStatus,
    DateTime FetchedAt,
    TitleRating? Rating,
    string? BackdropImageUrl,
    string? OriginalLanguage,
    float? ExternalScore,
    int? ExternalScoreCount,
    DateTime? ReleaseDate,
    decimal? ExternalPopularity,
    int? Runtime,
    int? Episodes,
    string? MediaType,
    int? AverageRuntime,
    AiredData? Aired,
    BroadcastData? Broadcast,
    List<Link>? AlternativeLinks,
    List<Link>? SocialLinks,
    List<Link>? StreamingLinks,
    List<Relation>? Relations,
    List<GenreMetadata> Genres);

public record GenreMetadata(
    string ExternalId,
    string Name
);