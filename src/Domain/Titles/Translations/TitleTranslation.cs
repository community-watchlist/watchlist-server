using Domain.Languages;

namespace Domain.Titles.Translations;

public class TitleTranslation
{
    public TitleTranslationId Id { get; }
    public TitleId TitleId { get; }
    public LanguageCode LanguageCode { get; }   
    public string TranslatedTitle { get; private set; }
    public string? Overview { get; private set; }

    public Title? Title { get; } = null;
    public Language? Language { get; } = null;
    
    private TitleTranslation(
        TitleTranslationId id,
        TitleId titleId,
        LanguageCode languageCode,
        string translatedTitle,
        string? overview)
    {
        Id = id;
        TitleId = titleId;
        LanguageCode = languageCode;
        TranslatedTitle = translatedTitle;
        Overview = overview;
    }
    
    public static TitleTranslation New(
        TitleTranslationId id,
        TitleId titleId,
        LanguageCode languageCode,
        string translatedTitle,
        string? overview) 
        => new(id, titleId, languageCode, translatedTitle, overview);

    public void Update(string translatedTitle, string? overview)
    {
        TranslatedTitle = translatedTitle;
        Overview = overview;
    }
}