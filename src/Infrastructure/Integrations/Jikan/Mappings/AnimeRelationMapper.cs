using Domain.Titles.Attributes;

namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeRelationMapper
{
    public static TitleRelationType ToDomainModel(string? relationName)
    {
        return relationName?.Trim().ToLowerInvariant() switch
        {
            "sequel" => TitleRelationType.Sequel,
            "prequel" => TitleRelationType.Prequel,
            "adaptation" => TitleRelationType.Adaptation,
            "side story" => TitleRelationType.SideStory,
            "parent story" => TitleRelationType.ParentStory,
            "summary" => TitleRelationType.Summary,
            "full story" => TitleRelationType.FullStory,
            "character" => TitleRelationType.Character,
            "alternative setting" => TitleRelationType.AlternativeStory,
            "alternative version" => TitleRelationType.AlternativeStory,
            _ => TitleRelationType.Other
        };
    }
        
}