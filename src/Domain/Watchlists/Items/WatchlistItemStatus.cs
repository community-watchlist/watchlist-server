using Domain.Common;

namespace Domain.Watchlists.Items;

public static class WatchlistItemStatusValues
{
    public const string Watching = "watching";
    public const string Completed = "completed";
    public const string OnHold = "on_hold";
    public const string Dropped = "dropped";
    public const string Planned = "planned";
}

public sealed class WatchlistItemStatus : ValueObject
{
    private string Value { get; }

    private WatchlistItemStatus(string value)
    {
        Value = value;
    }

    public static readonly WatchlistItemStatus Watching = new(WatchlistItemStatusValues.Watching);
    public static readonly WatchlistItemStatus Completed = new(WatchlistItemStatusValues.Completed);
    public static readonly WatchlistItemStatus OnHold = new(WatchlistItemStatusValues.OnHold);
    public static readonly WatchlistItemStatus Dropped = new(WatchlistItemStatusValues.Dropped);
    public static readonly WatchlistItemStatus Planned = new(WatchlistItemStatusValues.Planned);

    public static WatchlistItemStatus From(string value)
    {
        return value switch
        {
            WatchlistItemStatusValues.Watching => Watching,
            WatchlistItemStatusValues.Completed => Completed,
            WatchlistItemStatusValues.OnHold => OnHold,
            WatchlistItemStatusValues.Dropped => Dropped,
            WatchlistItemStatusValues.Planned => Planned,
            _ => throw new ArgumentException($"Invalid watchlist item status: {value}", nameof(value))
        };
    }

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}