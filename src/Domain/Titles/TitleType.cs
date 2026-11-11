using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Titles;

public static class TitleTypeValues
{
    public const string Movie = "movie";
    public const string Series = "series";
    public const string Anime = "anime";
}

public class TitleType : ValueObject
{
    private string Value { get; }

    private TitleType(string type)
    {
        Value = type;
    }

    public static TitleType From(string value)
    {
        var type = new TitleType(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid title type: {value}");
        }
        
        return type;
    }

    public static TitleType Movie => new(TitleTypeValues.Movie);
    public static TitleType Series => new(TitleTypeValues.Series);
    public static TitleType Anime => new(TitleTypeValues.Anime);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private static IEnumerable<TitleType> AllowedTypes
    {
        get
        {
            yield return Movie;
            yield return Series;
            yield return Anime;
        }
    }
}