namespace Domain.Episodes.Translations;

public record EpisodeTranslationId(Guid Value)
{
    public static EpisodeTranslationId Empty = new(Guid.Empty);
    public static EpisodeTranslationId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}