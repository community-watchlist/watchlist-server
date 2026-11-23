using Domain.Common;

namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeDateMapper
{
    public static DateTime? ToDateTime(DateOnly? dateOnly)
    {
        if (dateOnly is null) return null;
        
        return new DateTime((DateOnly)dateOnly, new TimeOnly(0, 0, 0), DateTimeKind.Utc);
    }

    public static DateTime? ToDateTime(string? value, string? pattern = null)
    {
        if (value is null) return null;

        if (pattern == null)
        {
            if (!DateTime.TryParse(value, out var date)) return null;

            return date;
        } 
        
        if (pattern == "YYYYMMDD")
        {
            if (!int.TryParse(value.Substring(0, 4), out int year)) return null;
            if (!int.TryParse(value.Substring(4, 2), out int month)) return null;
            if (!int.TryParse(value.Substring(6, 2), out int day)) return null;
            
            return new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
        }

        if (pattern == "YYYY-MM")
        {
            if (!int.TryParse(value.Substring(0, 4), out int year)) return null;
            if (!int.TryParse(value.Substring(5, 2), out int month)) return null;
            
            return new DateTime(year, month, 0, 0, 0, 0, DateTimeKind.Utc);
        }

        if (pattern == "MMM YYYY")
        {
            if (!DateTime.TryParse(value, out var date)) return null;

            return date;
        }

        return null;
    }

    public static int? ToMinutes(string? value, string? pattern = null)
    {
        if (value == null) return null;

        if (pattern == "HH:MM:SS")
        {
            var result = 0;
            
            var parts = value.Split(':');
            result += int.TryParse(parts[0], out int hours) ? hours * 60 : 0;
            result += int.TryParse(parts[1], out int minutes) ? minutes : 0;
            return result;
        }

        return null;
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