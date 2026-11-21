namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeDurationMapper
{
    public static int? ToMinutes(string? duration, int? episodes)
    {
        if (String.IsNullOrEmpty(duration) || episodes == null)
        {
            return null;
        }

        if (episodes != 1) return null;
        // Possible cases: 2 hr. 10 min. | 1 hr. | 34 min.
        var parts = duration.Split('.').Select(x => x.Trim());
        int runtime = 0;

        foreach (var part in parts)
        {
            var number = part.Split(' ')[0];
            
            if (part.Contains("hr"))
            {
                if (int.TryParse(number, out var result)) 
                    runtime += result * 60;
            }
            else if (part.Contains("min"))
            {
                
                if (int.TryParse(number, out var result)) 
                    runtime += result;
            }
        }
        
        if (runtime == 0) return null;
        return runtime;
    }
}