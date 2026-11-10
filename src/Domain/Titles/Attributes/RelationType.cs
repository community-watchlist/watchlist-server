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

public class RelationType : ValueObject
{
    private string Value { get; }

    private RelationType(string type)
    {
        Value = type;
    }

    public static RelationType From(string value)
    {
        var type = new RelationType(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid release status: {value}");
        }
        
        return type;
    }

    public static RelationType Sequel => new(RelationTypeValues.Sequel);
    public static RelationType Prequel => new(RelationTypeValues.Prequel);
    public static RelationType Adaptation => new(RelationTypeValues.Adaptation);
    public static RelationType SideStory => new(RelationTypeValues.SideStory);
    public static RelationType Other => new(RelationTypeValues.Other);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private static IEnumerable<RelationType> AllowedTypes
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