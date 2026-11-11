using Domain.Common;

namespace Domain.Languages;

public static class LanguageCodeValues
{
    public const string English = "en";
    public const string Ukrainian = "uk";
    public const string Spanish = "es";
    public const string Japanese = "ja";
}

public class LanguageCode : ValueObject
{
    public string Value { get; }

    private LanguageCode(string value)
    {
        Value = value;
    }

    public static readonly LanguageCode English =
        new(LanguageCodeValues.English);

    public static readonly LanguageCode Ukrainian =
        new(LanguageCodeValues.Ukrainian);

    public static readonly LanguageCode Spanish =
        new(LanguageCodeValues.Spanish);

    public static readonly LanguageCode Japanese =
        new(LanguageCodeValues.Japanese);

    public static LanguageCode From(string value)
    {
        return value switch
        {
            LanguageCodeValues.English => English,
            LanguageCodeValues.Ukrainian => Ukrainian,
            LanguageCodeValues.Spanish => Spanish,
            LanguageCodeValues.Japanese => Japanese,
            _ => throw new ArgumentException(
                $"Invalid language code: {value}")
        };
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}