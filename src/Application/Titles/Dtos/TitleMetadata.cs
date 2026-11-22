using Domain.Titles;
using Domain.Titles.Attributes;

namespace Application.Titles.Dtos;

public record TitleMetadata(
    TitleType Type,
    string Provider,
    string ExternalId,
    string OriginalTitle,
    string? Overview,
    TitlePosterMetadata? Poster,
    TitleReleaseStatus? TitleReleaseStatus,
    DateTime FetchedAt,
    TitleRating? Rating,
    string? OriginalLanguage,
    float? ExternalScore,
    int? ExternalScoreCount,
    DateTime? ReleaseDate,
    int? Episodes,
    string? MediaType);