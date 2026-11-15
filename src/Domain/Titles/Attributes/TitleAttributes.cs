using Domain.Common;

namespace Domain.Titles.Attributes;

public class TitleAttributes
{
    public TitleRating Rating { get; set; }
    
    public string? BackdropImageUrl { get; set; }
    
    public string? OriginalLanguage { get; set; }
    
    public float? ExternalScore { get; set; }
    
    public int? ExternalScoreCount { get; set; }
    
    public DateTime? ReleaseDate { get; set; }
    
    public decimal? ExternalPopularity { get; set; }
    
    /// Full runtime for movies
    public int? Runtime { get; set; }
    
    public int? Episodes { get; set; }
    
    /// Mostly for anime (TV, OVA, Movie, ...)
    public string? MediaType { get; set; }
    
    /// Average episode duration for episodicals
    public int? AverageRuntime { get; set; }
    
    public AiredData? Aired { get; set; }
    
    /// When do new episodes come out
    public BroadcastData? Broadcast { get; set; }
    
    /// Links to other databases (IMDB, MAL, etc.)
    public List<Link>? AlternativeLinks { get; set; }
    
    /// Links to various links related to the title (Wiki, official site, Bluesky)
    public List<Link>? SocialLinks { get; set; }
    
    /// Links to official resources to watch at
    public List<Link>? StreamingLinks { get; set; }
    
    /// Links to relatives of one title (sequel, prequel, adaptation, etc.)
    public List<Relation>? Relations { get; set; }

    private TitleAttributes(
        TitleRating rating,
        string? backdropImageUrl,
        string? originalLanguage,
        float? externalScore,
        int? externalScoreCount,
        DateTime? releaseDate,
        decimal? externalPopularity,
        int? runtime,
        int? episodes,
        string? mediaType,
        int? averageRuntime)
    {
        Rating = rating;
        BackdropImageUrl = backdropImageUrl;
        OriginalLanguage = originalLanguage;
        ExternalScore = externalScore;
        ExternalScoreCount = externalScoreCount;
        ReleaseDate = releaseDate;
        ExternalPopularity = externalPopularity;
        Runtime = runtime;
        Episodes = episodes;
        MediaType = mediaType;
        AverageRuntime = averageRuntime;
    }

    public static TitleAttributes New(
        TitleRating? rating,
        string? backdropImageUrl,
        string? originalLanguage,
        float? externalScore,
        int? externalScoreCount,
        DateTime? releaseDate,
        decimal? externalPopularity,
        int? runtime,
        int? episodes,
        string? mediaType,
        int? averageRuntime,
        AiredData? aired,
        BroadcastData? broadcast,
        List<Link>? alternativeLinks,
        List<Link>? socialLinks,
        List<Link>? streamingLinks,
        List<Relation>? relations)
        => new(
            rating ?? TitleRating.NR,
            backdropImageUrl,
            originalLanguage,
            externalScore,
            externalScoreCount,
            releaseDate,
            externalPopularity,
            runtime,
            episodes,
            mediaType,
            averageRuntime)
        {
            Aired = aired,
            Broadcast = broadcast,
            AlternativeLinks = alternativeLinks,
            SocialLinks = socialLinks,
            StreamingLinks = streamingLinks,
            Relations = relations
        };

    public void Update(
        TitleRating? rating,
        string? backdropImageUrl,
        string? originalLanguage,
        float? externalScore,
        int? externalScoreCount,
        DateTime? releaseDate,
        decimal? externalPopularity,
        int? runtime,
        int? episodes,
        string? mediaType,
        int? averageRuntime,
        AiredData? aired,
        BroadcastData? broadcast,
        List<Link>? alternativeLinks,
        List<Link>? socialLinks,
        List<Link>? streamingLinks,
        List<Relation>? relations)
    {
        Rating = rating ?? Rating;
        BackdropImageUrl = backdropImageUrl;
        OriginalLanguage = originalLanguage;
        ExternalScore = externalScore;
        ExternalScoreCount = externalScoreCount;
        ReleaseDate = releaseDate;
        ExternalPopularity = externalPopularity;
        Runtime = runtime;
        Episodes = episodes;
        MediaType = mediaType;
        AverageRuntime = averageRuntime;
        Aired = aired;
        Broadcast = broadcast;
        AlternativeLinks = alternativeLinks;
        SocialLinks = socialLinks;
        StreamingLinks = streamingLinks;
        Relations = relations;
    }
}

public class AiredData
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    private AiredData(DateTime? from, DateTime? to)
    {
        From = from;
        To = to;
    }

    public static AiredData New(DateTime? from, DateTime? to)
        => new(from, to);
}

public class BroadcastData
{
    public WeekDay WeekDay { get; set; }
    public string? Time { get; set; }

    private BroadcastData(WeekDay weekDay, string? time)
    {
        WeekDay = weekDay;
        Time = time;
    }
    
    public static BroadcastData New(WeekDay weekDay, string? time)
        => new(weekDay, time);
}

public class Link
{
    public string? SiteName { get; set; }
    public string Url { get; set; }

    private Link(string? siteName, string url)
    {
        SiteName = siteName;
        Url = url;
    }
    
    public static Link New(string? siteName, string url)
        => new(siteName, url);
}

public class Relation
{
    public TitleRelationType TitleRelationType { get; set; }
    public string? OriginalTitle { get; set; }
    public string ExternalId { get; set; }

    private Relation(TitleRelationType titleRelationType, string? originalTitle, string externalId)
    {
        TitleRelationType = titleRelationType;
        OriginalTitle = originalTitle;
        ExternalId = externalId;
    }
    
    public static Relation New(TitleRelationType titleRelationType, string? originalTitle, string externalId)
        => new(titleRelationType, originalTitle, externalId);
}