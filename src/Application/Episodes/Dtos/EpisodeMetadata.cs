using Domain.Episodes.Attributes;

namespace Application.Episodes.Dtos;

public record EpisodeMetadata(
    string Provider,
    string ExternalId,
    string ExternalTitleId,
    string OriginalTitle,
    string? Overview,
    int Position,
    DateTime FetchedAt,
    int? Runtime,
    string? PosterUrl,
    DateTime? ReleaseDate,
    float? ExternalScore,
    int? ExternalScoreCount,
    List<Link>? AlternativeLinks,
    List<Link>? StreamingLinks
);