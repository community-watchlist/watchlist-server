using Domain.Common;

namespace Domain.Titles.Attributes;

public static class TitleRelationTypeValues
{
    /// Comes after the title, continues it
    public const string Sequel = "sequel";
    
    /// Comes before the title
    public const string Prequel = "prequel";
    
    /// More broad story of the title
    public const string ParentStory = "parent_story";
    
    /// Additional story within the same universe of that title
    public const string SideStory = "side_story";
    
    // Adapts that title
    public const string Adaptation = "adaptation";

    /// A recap or condensed version of a title
    public const string Summary = "summary";
    
    /// More complete version of the title
    public const string FullStory = "full_story";
    
    /// Another interpretation or version of title
    public const string AlternativeStory = "alternative_story";
    
    /// Shares or focuses on the character from that title
    public const string Character = "character";
    
    /// For all others and movies as they appear to not have any connections
    public const string Other = "other";
    
    /// Since TMDB does not provide any connection data,
    /// that's the only way to reliably relate anything to anything else
    public const string Recommendation = "recommendations";
}

public class TitleRelationType : ValueObject
{
    private string Value { get; }

    private TitleRelationType(string type)
    {
        Value = type;
    }

    public static TitleRelationType From(string value)
    {
        var type = new TitleRelationType(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid relation type: {value}");
        }
        
        return type;
    }
    
    /// Comes after the title, continues it
    public static TitleRelationType Sequel => new(TitleRelationTypeValues.Sequel);
    
    /// Comes before the title
    public static TitleRelationType Prequel => new(TitleRelationTypeValues.Prequel);
    
    /// More broad story of the title
    public static TitleRelationType ParentStory => new(TitleRelationTypeValues.ParentStory);
    
    /// Additional story within the same universe of that title
    public static TitleRelationType SideStory => new(TitleRelationTypeValues.SideStory);
    
    // Adapts that title
    public static TitleRelationType Adaptation => new(TitleRelationTypeValues.Adaptation);

    /// A recap or condensed version of a title
    public static TitleRelationType Summary => new(TitleRelationTypeValues.Summary);
    
    /// More complete version of the title
    public static TitleRelationType FullStory => new(TitleRelationTypeValues.FullStory);
    
    /// Another interpretation or version of title
    public static TitleRelationType AlternativeStory => new(TitleRelationTypeValues.AlternativeStory);
    
    /// Shares or focuses on the character from that title
    public static TitleRelationType Character => new(TitleRelationTypeValues.Character);
    
    /// For all others and movies as they appear to not have any connections
    public static TitleRelationType Other => new(TitleRelationTypeValues.Other);
    
    /// Since TMDB does not provide any connection data,
    /// that's the only way to reliably relate anything to anything else
    public static TitleRelationType Recommendation => new(TitleRelationTypeValues.Recommendation);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public override string ToString() => Value;
    
    private static IEnumerable<TitleRelationType> AllowedTypes
    {
        get
        {
            yield return Sequel;
            yield return Prequel;
            yield return ParentStory;
            yield return SideStory;
            yield return Adaptation;
            yield return Summary;
            yield return FullStory;
            yield return AlternativeStory;
            yield return Character;
            yield return Other;
            yield return Recommendation;
        }
    }
}