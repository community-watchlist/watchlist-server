namespace Domain.Episodes.Properties;

public class EpisodeProperties
{
    public EpisodePropertiesId Id { get; }
    public EpisodeId EpisodeId { get; private set; }
    public string Slug { get; private set; }
    public float? ScoreAverage { get; private set; }
    public int ScoreCount { get; private set; }
    public int Views { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private EpisodeProperties(
        EpisodePropertiesId id,
        EpisodeId episodeId,
        string slug,
        float? scoreAverage,
        int scoreCount,
        int views,
        DateTime updatedAt)
    {
        Id = id;
        EpisodeId = episodeId;
        Slug = slug;
        ScoreAverage = scoreAverage;
        ScoreCount = scoreCount;
        Views = views;
        UpdatedAt = updatedAt;
    }

    public static EpisodeProperties New(
        EpisodePropertiesId id,
        EpisodeId episodeId,
        string slug,
        float? scoreAverage,
        int? scoreCount,
        int? views)
        => new(
            id,
            episodeId,
            slug,
            scoreAverage,
            scoreCount ?? 0,
            views ?? 0,
            DateTime.UtcNow);

    public void Update(
        string slug,
        float? scoreAverage,
        int? scoreCount,
        int? views)
    {
        Slug = slug;
        ScoreAverage = scoreAverage;
        ScoreCount = scoreCount ?? 0;
        Views = views ?? 0;
        UpdatedAt = DateTime.UtcNow;
    }
}