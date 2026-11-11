using Domain.Titles.Attributes;

namespace Domain.Titles;

public class Title
{
    public TitleId Id { get; }
    public TitleType Type { get; private set; }
    public string Provider { get; private set; }
    public string ExternalId { get; private set; }
    public string OriginalTitle { get; private set; }
    public string? Overview { get; private set; }
    public ReleaseStatus ReleaseStatus { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public DateTime? FetchedAt { get; private set; }
    public TitleAttributes? Attributes { get; private set; }

    private Title(
        TitleId id,
        TitleType type,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        ReleaseStatus releaseStatus,
        DateTime createdAt)
    {
        Id = id;
        Type = type;
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        ReleaseStatus = releaseStatus;
        CreatedAt = createdAt;
    }

    public static Title New(
        TitleId id,
        TitleType type,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        ReleaseStatus? releaseStatus,
        TitleAttributes? attributes)
        => new(
            id,
            type,
            provider,
            externalId,
            originalTitle,
            overview,
            releaseStatus ?? ReleaseStatus.NotYetReleased,
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
        ReleaseStatus releaseStatus,
        DateTime? fetchedAt,
        TitleAttributes? attributes = null)
    {
        Type = type;
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        ReleaseStatus = releaseStatus;
        Attributes = attributes;
        FetchedAt = fetchedAt;
        UpdatedAt = DateTime.UtcNow;
    }
}