namespace Domain.Titles.Properties;

public class TitleProperties
{
    public TitlePropertiesId Id { get; }
    public TitleId TitleId { get; private set; }
    public string Slug { get; private set; }
    public float? ScoreAverage { get; private set; }
    public int? ScoreCount { get; private set; }
    public int Views { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    private TitleProperties(
        TitlePropertiesId id,
        TitleId titleId,
        string slug,
        float? scoreAverage,
        int scoreCount,
        int views,
        DateTime updatedAt)
    {
        Id = id;
        TitleId = titleId;
        Slug = slug;
        ScoreAverage = scoreAverage;
        ScoreCount = scoreCount;
        Views = views;
        UpdatedAt = updatedAt;
    }

    public static TitleProperties New(
        TitlePropertiesId id,
        TitleId titleId,
        string slug,
        float? scoreAverage,
        int? scoreCount,
        int? views)
        => new(
            id,
            titleId,
            slug,
            scoreAverage,
            scoreCount ?? 0,
            views ?? 0,
            DateTime.UtcNow);

    public void Update(
        TitleId titleId,
        string slug,
        float? scoreAverage,
        int? scoreCount,
        int? views)
    {
        TitleId = titleId;
        Slug = slug;
        ScoreAverage = scoreAverage;
        ScoreCount = scoreCount ?? ScoreCount;
        Views = views ?? Views;
        UpdatedAt = DateTime.UtcNow;
    }
}