using Domain.Languages;

namespace Domain.Episodes.Translations;

public class EpisodeTranslation
{
    public EpisodeTranslationId Id { get; }
    public EpisodeId EpisodeId { get; }
    public LanguageCode LanguageCode { get; }   
    public string Name { get; private set; }
    public string? Overview { get; private set; }

    private EpisodeTranslation(
        EpisodeTranslationId id,
        EpisodeId episodeId,
        LanguageCode languageCode,
        string name,
        string? overview)
    {
        Id = id;
        EpisodeId = episodeId;
        LanguageCode = languageCode;
        Name = name;
        Overview = overview;
    }
    
    public static EpisodeTranslation New(
        EpisodeTranslationId id,
        EpisodeId episodeId,
        LanguageCode languageCode,
        string name,
        string? overview) 
        => new(id, episodeId, languageCode, name, overview);

    public void Update(string name, string? overview)
    {
        Name = name;
        Overview = overview;
    }
}