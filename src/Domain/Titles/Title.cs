using Domain.Episodes;
using Domain.Titles.Attributes;
using Domain.Titles.Poster;
using Domain.Titles.Properties;

namespace Domain.Titles;

public class Title
{
    public TitleId Id { get; }
    public TitleType Type { get; private set; }
    public string Provider { get; private set; }
    public string ExternalId { get; private set; }
    public string OriginalTitle { get; private set; }
    public string? Overview { get; private set; }
    public TitleReleaseStatus TitleReleaseStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public DateTime? FetchedAt { get; private set; }
    public TitleAttributes? Attributes { get; private set; }

    public TitleProperties? Properties { get; } = null;
    public TitlePoster? Poster { get; } = null;
    // TODO: add Episodes
    // TODO: add Translations
    // TODO: add Genres

    private Title(
        TitleId id,
        TitleType type,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        TitleReleaseStatus titleReleaseStatus,
        DateTime? fetchedAt,
        DateTime createdAt)
    {
        Id = id;
        Type = type;
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        TitleReleaseStatus = titleReleaseStatus;
        FetchedAt = fetchedAt;
        CreatedAt = createdAt;
    }

    public static Title New(
        TitleId id,
        TitleType type,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        TitleReleaseStatus? releaseStatus,
        DateTime? fetchedAt,
        TitleAttributes? attributes)
        => new(
            id,
            type,
            provider,
            externalId,
            originalTitle,
            overview,
            releaseStatus ?? TitleReleaseStatus.NotYetReleased,
            fetchedAt,
            DateTime.UtcNow)
        {
            Attributes = attributes
        };

    public void Update(
        TitleType type,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        TitleReleaseStatus titleReleaseStatus,
        DateTime? fetchedAt,
        TitleAttributes? attributes)
    {
        Type = type;
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        TitleReleaseStatus = titleReleaseStatus;
        FetchedAt = fetchedAt;
        Attributes = attributes;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}