using Domain.Titles;

namespace Infrastructure.Integrations.Jikan.Mappings;

public static class AnimeReleaseStatusMapper
{
    public static TitleReleaseStatus ToDomainModel(string? releaseStatus)
    {
        return releaseStatus?.Trim().ToLowerInvariant() switch
        {
            "finished airing" => TitleReleaseStatus.Finished,
            "not yet aired" => TitleReleaseStatus.NotYetReleased,
            "currently airing" => TitleReleaseStatus.Releasing,
            _ => TitleReleaseStatus.NotYetReleased
        };
    }
    
}