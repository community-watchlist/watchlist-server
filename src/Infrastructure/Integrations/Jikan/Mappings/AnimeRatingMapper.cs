using Domain.Titles.Attributes;

namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeRatingMapper
{
    public static TitleRating ToDomainModel(string? rating)
    {
        if (string.IsNullOrEmpty(rating)) return TitleRating.NR;
        
        return rating.Trim().ToLowerInvariant() switch
        {
            var value when value.StartsWith("nr") => TitleRating.NR,
            var value when value.StartsWith("r+") => TitleRating.NC17,
            var value when value.StartsWith("rx") => TitleRating.NC17,
            var value when value.StartsWith("r") => TitleRating.R,
            var value when value.StartsWith("pg-13") => TitleRating.PG13,
            var value when value.StartsWith("pg") => TitleRating.PG,
            var value when value.StartsWith("g") => TitleRating.G,
            _ => TitleRating.NR
        };
    }
    
}