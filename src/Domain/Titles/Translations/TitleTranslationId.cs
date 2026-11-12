namespace Domain.Titles.Translations;

public record TitleTranslationId(Guid Value)
{
    public static TitleTranslationId Empty = new(Guid.Empty);
    public static TitleTranslationId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}