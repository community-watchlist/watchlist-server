using Domain.Languages;

namespace Domain.Episodes.Translations;

public class EpisodeTranslation
{
    public EpisodeTranslationId Id { get; }
    public EpisodeId EpisodeId { get; }
    public LanguageCode LanguageCode { get; }   
    public string TranslatedTitle { get; private set; }
    public string? Overview { get; private set; }

    private EpisodeTranslation(
        EpisodeTranslationId id,
        EpisodeId episodeId,
        LanguageCode languageCode,
        string translatedTitle,
        string? overview)
    {
        Id = id;
        EpisodeId = episodeId;
        LanguageCode = languageCode;
        TranslatedTitle = translatedTitle;
        Overview = overview;
    }
    
    public static EpisodeTranslation New(
        EpisodeTranslationId id,
        EpisodeId episodeId,
        LanguageCode languageCode,
        string translatedTitle,
        string? overview) 
        => new(id, episodeId, languageCode, translatedTitle, overview);

    public void Update(string translatedTitle, string? overview)
    {
        TranslatedTitle = translatedTitle;
        Overview = overview;
    }
}