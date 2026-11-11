namespace Domain.Watchlists.Banner;

public record WatchlistBannerId(Guid Value)
{
    public static WatchlistBannerId Empty = new(Guid.Empty);
    public static WatchlistBannerId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}