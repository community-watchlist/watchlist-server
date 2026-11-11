namespace Domain.Watchlists.Items.Attributes;

public class WatchlistItemAttributes
{
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    private WatchlistItemAttributes(
        DateTime? startedAt, 
        DateTime? finishedAt)
    {
        StartedAt = startedAt;
        FinishedAt = finishedAt;
    }
    
    public static WatchlistItemAttributes New(
        DateTime? startedAt, 
        DateTime? finishedAt)
    => new(startedAt, finishedAt);

    public void Update(
        DateTime? startedAt,
        DateTime? finishedAt)
    {
        StartedAt = startedAt;
        FinishedAt = finishedAt;
    }
}