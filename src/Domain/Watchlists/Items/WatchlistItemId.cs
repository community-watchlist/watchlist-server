namespace Domain.Watchlists.Items;

public record WatchlistItemId(Guid Value)
{
    public static WatchlistItemId Empty = new(Guid.Empty);
    public static WatchlistItemId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}