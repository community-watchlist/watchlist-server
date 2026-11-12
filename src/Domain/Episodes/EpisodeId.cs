namespace Domain.Episodes;

public record EpisodeId(Guid Value) 
{
    public static EpisodeId Empty = new(Guid.Empty);
    public static EpisodeId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}