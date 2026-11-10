using Domain.Common;

namespace Domain.Titles;

public static class ReleaseStatusValues
{
    public const string NotYetReleased = "not_yet_released";
    public const string Cancelled = "cancelled";
    public const string Hiatus = "hiatus";
    public const string Releasing = "releasing";
    public const string Finished = "finished";
}

public class ReleaseStatus : ValueObject
{
    private string Value { get; }

    private ReleaseStatus(string type)
    {
        Value = type;
    }

    public static ReleaseStatus From(string value)
    {
        var type = new ReleaseStatus(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid release status: {value}");
        }
        
        return type;
    }

    public static ReleaseStatus NotYetReleased => new(ReleaseStatusValues.NotYetReleased);
    public static ReleaseStatus Cancelled => new(ReleaseStatusValues.Cancelled);
    public static ReleaseStatus Hiatus => new(ReleaseStatusValues.Hiatus);
    public static ReleaseStatus Releasing => new(ReleaseStatusValues.Releasing);
    public static ReleaseStatus Finished => new(ReleaseStatusValues.Finished);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    private static IEnumerable<ReleaseStatus> AllowedTypes
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