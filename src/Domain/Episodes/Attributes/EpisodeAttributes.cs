namespace Domain.Episodes.Attributes;

public class EpisodeAttributes
{
    public int? Runtime { get; set; }
    public string? PosterUrl { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public float? ExternalScore { get; set; }
    public int? ExternalScoreCount { get; set; }
    public List<Link>? AlternativeLinks { get; set; }
    public List<Link>? StreamingLinks { get; set; }

    private EpisodeAttributes(
        int? runtime,
        string? posterUrl,
        DateTime? releaseDate,
        float? externalScore,
        int? externalScoreCount,
        List<Link>? alternativeLinks,
        List<Link>? streamingLinks)
    {
        Runtime = runtime;
        PosterUrl = posterUrl;
        ReleaseDate = releaseDate;
        ExternalScore = externalScore;
        ExternalScoreCount = externalScoreCount;
        AlternativeLinks = alternativeLinks;
        StreamingLinks = streamingLinks;
    }

    public static EpisodeAttributes New(
        int? runtime,
        string? posterUrl,
        DateTime? releaseDate,
        float? externalScore,
        int? externalScoreCount,
        List<Link>? alternativeLinks,
        List<Link>? streamingLinks)
        => new(
            runtime,
            posterUrl,
            releaseDate,
            externalScore,
            externalScoreCount,
            alternativeLinks,
            streamingLinks);

    public void Update(
        int? runtime,
        string? posterUrl,
        DateTime? releaseDate,
        float? externalScore,
        int? externalScoreCount,
        List<Link>? alternativeLinks,
        List<Link>? streamingLinks)
    {
        Runtime = runtime;
        PosterUrl = posterUrl;
        ReleaseDate = releaseDate;
        ExternalScore = externalScore;
        ExternalScoreCount = externalScoreCount;
        AlternativeLinks = alternativeLinks;
        StreamingLinks = streamingLinks;
    }
}

public record Link
{
    public string? SiteName { get; set; }
    public string Url { get; set; }
}