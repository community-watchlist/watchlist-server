using Domain.Languages;

namespace Domain.Genres.Translations;

public class GenreTranslation
{
    public GenreTranslationId Id { get; }
    public GenreId GenreId { get; }
    public LanguageCode LanguageCode { get; }   
    public string Name { get; private set; }

    private GenreTranslation(
        GenreTranslationId id,
        GenreId genreId,
        LanguageCode languageCode,
        string name)
    {
        Id = id;
        GenreId = genreId;
        LanguageCode = languageCode;
        Name = name;
    }
    
    public static GenreTranslation New(
        GenreTranslationId id,
        GenreId genreId,
        LanguageCode languageCode,
        string name) 
        => new(id, genreId, languageCode, name);

    public void Update(string name)
    {
        Name = name;
    }
}