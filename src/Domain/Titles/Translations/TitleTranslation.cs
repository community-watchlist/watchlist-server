using Domain.Languages;

namespace Domain.Titles.Translations;

public class TitleTranslation
{
    public TitleTranslationId Id { get; }
    public TitleId TitleId { get; }
    public LanguageCode LanguageCode { get; }   
    public string Name { get; private set; }
    public string? Overview { get; private set; }

    private TitleTranslation(
        TitleTranslationId id,
        TitleId titleId,
        LanguageCode languageCode,
        string name,
        string? overview)
    {
        Id = id;
        TitleId = titleId;
        LanguageCode = languageCode;
        Name = name;
        Overview = overview;
    }
    
    public static TitleTranslation New(
        TitleTranslationId id,
        TitleId titleId,
        LanguageCode languageCode,
        string name,
        string? overview) 
        => new(id, titleId, languageCode, name, overview);

    public void Update(string name, string? overview)
    {
        Name = name;
        Overview = overview;
    }
}