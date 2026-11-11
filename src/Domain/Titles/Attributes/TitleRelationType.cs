using Domain.Common;

namespace Domain.Titles.Attributes;

// TODO: review those types and add new ones
public static class RelationTypeValues
{
    public const string Sequel = "sequel";
    public const string Prequel = "prequel";
    public const string Adaptation = "adaptation";
    public const string SideStory = "side_story";
    public const string Other = "other";
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

    public static TitleRelationType Sequel => new(RelationTypeValues.Sequel);
    public static TitleRelationType Prequel => new(RelationTypeValues.Prequel);
    public static TitleRelationType Adaptation => new(RelationTypeValues.Adaptation);
    public static TitleRelationType SideStory => new(RelationTypeValues.SideStory);
    public static TitleRelationType Other => new(RelationTypeValues.Other);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private static IEnumerable<TitleRelationType> AllowedTypes
    {
        get
        {
            yield return Sequel;
            yield return Prequel;
            yield return Adaptation;
            yield return SideStory;
            yield return Other;
        }
    }
}