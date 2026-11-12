namespace Domain.Episodes.Properties;

public record EpisodePropertiesId(Guid Value)
{
    public static EpisodePropertiesId Empty = new(Guid.Empty);
    public static EpisodePropertiesId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}