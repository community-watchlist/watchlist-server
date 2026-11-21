using Domain.Genres;
using Domain.Titles;
using Domain.Titles.Attributes;

namespace Application.Titles.Dtos;

public record TitleDetailsMetadata(
    TitleType Type,
    string Provider,
    string ExternalId,
    string OriginalTitle,
    string? Overview,
    TitleReleaseStatus TitleReleaseStatus,
    DateTime? FetchedAt,
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
    List<GenreMetadata> Genres)
{
    public static Title ToDomainModel(TitleDetailsMetadata metadata)
        => Title.New(
            id: TitleId.New(),
            type: metadata.Type,
            provider: metadata.Provider,
            externalId: metadata.ExternalId,
            originalTitle: metadata.OriginalTitle,
            overview: metadata.Overview,
            releaseStatus: metadata.TitleReleaseStatus,
            fetchedAt: metadata.FetchedAt,
            attributes: TitleAttributes.New(
                rating: metadata.Rating,
                backdropImageUrl: metadata.BackdropImageUrl,
                originalLanguage: metadata.OriginalLanguage,
                externalScore: metadata.ExternalScore,
                externalScoreCount: metadata.ExternalScoreCount,
                releaseDate: metadata.ReleaseDate,
                externalPopularity: metadata.ExternalPopularity,
                runtime: metadata.Runtime,
                episodes: metadata.Episodes,
                mediaType: metadata.MediaType,
                averageRuntime: metadata.AverageRuntime,
                aired: metadata.Aired,
                broadcast: metadata.Broadcast,
                alternativeLinks: metadata.AlternativeLinks,
                socialLinks: metadata.SocialLinks,
                streamingLinks: metadata.StreamingLinks,
                relations: metadata.Relations));

    public static Genre ToDomainModel(GenreMetadata metadata)
        => Genre.New(
            id: GenreId.New(),
            originalName: metadata.Name);
}

public record GenreMetadata(
    string ExternalId,
    string Name
);