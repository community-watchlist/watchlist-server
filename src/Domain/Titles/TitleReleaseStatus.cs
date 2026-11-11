using Domain.Common;

namespace Domain.Titles;

public static class TitleReleaseStatusValues
{
    public const string NotYetReleased = "not_yet_released";
    public const string Cancelled = "cancelled";
    public const string Hiatus = "hiatus";
    public const string Releasing = "releasing";
    public const string Finished = "finished";
}

public class TitleReleaseStatus : ValueObject
{
    private string Value { get; }

    private TitleReleaseStatus(string type)
    {
        Value = type;
    }

    public static TitleReleaseStatus From(string value)
    {
        var type = new TitleReleaseStatus(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid release status: {value}");
        }
        
        return type;
    }

    public static TitleReleaseStatus NotYetReleased => new(TitleReleaseStatusValues.NotYetReleased);
    public static TitleReleaseStatus Cancelled => new(TitleReleaseStatusValues.Cancelled);
    public static TitleReleaseStatus Hiatus => new(TitleReleaseStatusValues.Hiatus);
    public static TitleReleaseStatus Releasing => new(TitleReleaseStatusValues.Releasing);
    public static TitleReleaseStatus Finished => new(TitleReleaseStatusValues.Finished);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private static IEnumerable<TitleReleaseStatus> AllowedTypes
    {
        get
        {
            yield return NotYetReleased;
            yield return Cancelled;
            yield return Hiatus;
            yield return Releasing;
            yield return Finished;
        }
    }
}