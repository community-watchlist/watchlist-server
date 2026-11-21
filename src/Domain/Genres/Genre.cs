using Domain.Genres.Translations;
using Domain.Titles;

namespace Domain.Genres;

public class Genre
{
    public GenreId Id { get; }
    public string OriginalName { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public ICollection<TitleGenre>? TitleGenres { get; } = null;
    public ICollection<GenreTranslation>? GenreTranslations { get; } = null;
    
    private Genre(GenreId id, string originalName, DateTime createdAt)
    {
        Id = id;
        OriginalName = originalName;
        CreatedAt = createdAt;
    }

    public static Genre New(
        GenreId id,
        string originalName)
        => new(id, originalName, DateTime.UtcNow);

    public void Update(string originalName)
    {
        OriginalName = originalName;
    }
}