namespace Domain.Genres.Translations;

public record GenreTranslationId(Guid Value)
{
    public static GenreTranslationId Empty = new(Guid.Empty);
    public static GenreTranslationId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}