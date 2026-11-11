namespace Domain.Watchlists.Banner;

public record WatchlistBannerId(Guid Value)
{
    public static WatchlistBannerId Empty = new WatchlistBannerId(Guid.Empty);
    public static WatchlistBannerId New() => new WatchlistBannerId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}