namespace Domain.Watchlists;

public record WatchlistId(Guid Value)
{
    public static WatchlistId Empty = new(Guid.Empty);
    public static WatchlistId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}