namespace Domain.Watchlists;

public record WatchlistId(Guid Value)
{
    public static WatchlistId Empty = new WatchlistId(Guid.Empty);
    public static WatchlistId New() => new WatchlistId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}