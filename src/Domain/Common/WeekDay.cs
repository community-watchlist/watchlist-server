namespace Domain.Common;

public static class WeekDayValues
{
    public const string Monday = "monday";
    public const string Tuesday = "tuesday";
    public const string Wednesday = "wednesday";
    public const string Thursday = "thursday";
    public const string Friday = "friday";
    public const string Saturday = "saturday";
    public const string Sunday = "sunday";
}

public class WeekDay : ValueObject
{
    private string Value { get; }

    private WeekDay(string type)
    {
        Value = type;
    }

    public static WeekDay From(string value)
    {
        var type = new WeekDay(value);

        if (!AllowedTypes.Contains(type))
        {
            throw new ArgumentException($"Invalid day of week: {value}");
        }
        
        return type;
    }
    
    public static WeekDay Monday => new(WeekDayValues.Monday);
    public static WeekDay Tuesday => new(WeekDayValues.Tuesday);
    public static WeekDay Wednesday => new(WeekDayValues.Wednesday);
    public static WeekDay Thursday => new(WeekDayValues.Thursday);
    public static WeekDay Friday => new(WeekDayValues.Friday);
    public static WeekDay Saturday => new(WeekDayValues.Saturday);
    public static WeekDay Sunday => new(WeekDayValues.Sunday);
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public override string ToString() => Value;
    
    private static IEnumerable<WeekDay> AllowedTypes
    {
        get
        {
            yield return Monday;
            yield return Tuesday;
            yield return Wednesday;
            yield return Thursday;
            yield return Friday;
            yield return Saturday;
            yield return Sunday;
        }
    }
}