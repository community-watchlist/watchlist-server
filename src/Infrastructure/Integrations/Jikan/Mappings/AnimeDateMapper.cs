using Domain.Common;

namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeDateMapper
{
    public static DateTime? ToDateTime(DateOnly? dateOnly)
    {
        if (dateOnly is null) return null;
        
        return new DateTime((DateOnly)dateOnly, new TimeOnly(0, 0, 0));
    }

    public static WeekDay? ToWeekDay(string? day)
    {
        if (day is null) return null;

        return day.Trim().ToLowerInvariant() switch
        {
            var value when value.Contains("monday") => WeekDay.Monday,
            var value when value.Contains("tuesday") => WeekDay.Tuesday,
            var value when value.Contains("wednesday") => WeekDay.Wednesday,
            var value when value.Contains("thursday") => WeekDay.Thursday,
            var value when value.Contains("friday") => WeekDay.Friday,
            var value when value.Contains("saturday") => WeekDay.Saturday,
            var value when value.Contains("sunday") => WeekDay.Sunday,
            _ => null
        };
    }
}