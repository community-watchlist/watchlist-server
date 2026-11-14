using Domain.Common;

namespace Domain.Titles.Attributes;

public static class TitleRatingValues
{
    /// Not Rated
    public const string NR = "NR";
    /// General Audiences
    public const string G = "G";
    /// Parental Guidance Suggested
    public const string PG = "PG";
    /// Parents Strongly Cautioned 
    public const string PG13 = "PG-13";
    /// Restricted
    public const string R = "R";
    /// Adults Only
    public const string NC17 = "NC-17";
}

public class TitleRating : ValueObject
{
    private string Value { get; }

    private TitleRating(string type)
    {
        Value = type;
    }

    public static TitleRating From(string value)
    {
        var type = new TitleRating(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid title rating: {value}");
        }
        
        return type;
    }
    
    /// Not Rated
    public static TitleRating NR => new(TitleRatingValues.NR);
    
    /// General Audiences
    public static TitleRating G => new(TitleRatingValues.G);
    
    /// Parental Guidance Suggested
    public static TitleRating PG => new(TitleRatingValues.PG);
    
    /// Parents Strongly Cautioned
    public static TitleRating PG13 => new(TitleRatingValues.PG13);
    
    /// Restricted
    public static TitleRating R => new(TitleRatingValues.R);
    
    /// Adults Only
    public static TitleRating NC17 => new(TitleRatingValues.NC17);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public override string ToString() => Value;
    
    private static IEnumerable<TitleRating> AllowedTypes
    {
        get
        {
            yield return NR;
            yield return G;
            yield return PG;
            yield return PG13;
            yield return R;
            yield return NC17;
        }
    }
}