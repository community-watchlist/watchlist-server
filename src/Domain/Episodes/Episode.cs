using Domain.Episodes.Attributes;
using Domain.Titles;

namespace Domain.Episodes;

public class Episode
{
    public EpisodeId Id { get; }
    public TitleId TitleId { get; private set; }
    public string Provider { get; private set; }
    public string ExternalId { get; private set; }
    public string OriginalTitle { get; private set; }
    public string? Overview { get; private set; }
    public int Position { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public DateTime? FetchedAt { get; private set; }
    public EpisodeAttributes? Attributes { get; private set; }

    private Episode(
        EpisodeId id,
        TitleId titleId,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        int position,
        DateTime? fetchedAt,
        DateTime createdAt)
    {
        Id = id;
        TitleId = titleId;
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        Position = position;
        FetchedAt = fetchedAt;
        CreatedAt = createdAt;
    }

    public static Episode New(
        EpisodeId id,
        TitleId titleId,
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        int position,
        DateTime? fetchedAt,
        EpisodeAttributes? attributes)
        => new (
            id,
            titleId,
            provider,
            externalId,
            originalTitle,
            overview,
            position,
            fetchedAt,
            DateTime.UtcNow)
        {
            Attributes = attributes
        };

    public void Update(
        string provider,
        string externalId,
        string originalTitle,
        string? overview,
        int position,
        DateTime? fetchedAt,
        EpisodeAttributes? attributes)
    {
        Provider = provider;
        ExternalId = externalId;
        OriginalTitle = originalTitle;
        Overview = overview;
        Position = position;
        FetchedAt = fetchedAt;
        Attributes = attributes;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}