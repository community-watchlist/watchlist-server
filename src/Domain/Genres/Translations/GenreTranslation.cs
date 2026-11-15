using Domain.Languages;

namespace Domain.Genres.Translations;

public class GenreTranslation
{
    public GenreTranslationId Id { get; }
    public GenreId GenreId { get; }
    public LanguageCode LanguageCode { get; }   
    public string TranslatedName { get; private set; }

    public Genre? Genre { get; } = null;
    public Language? Language { get; } = null;
    
    private GenreTranslation(
        GenreTranslationId id,
        GenreId genreId,
        LanguageCode languageCode,
        string translatedName)
    {
        Id = id;
        GenreId = genreId;
        LanguageCode = languageCode;
        TranslatedName = translatedName;
    }
    
    public static GenreTranslation New(
        GenreTranslationId id,
        GenreId genreId,
        LanguageCode languageCode,
        string translatedName) 
        => new(id, genreId, languageCode, translatedName);

    public void Update(string translatedName)
    {
        TranslatedName = translatedName;
    }
}