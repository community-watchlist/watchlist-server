using Domain.Titles;
using Domain.Watchlists.Items.Attributes;

namespace Domain.Watchlists.Items;

public class WatchlistItem
{
    public WatchlistItemId Id { get; }
    public WatchlistId WatchlistId { get; private set; }
    public TitleId TitleId { get; private set; }
    public WatchlistItemStatus Status { get; private set; }
    public int Progress { get; private set; }
    public string? Tags { get; private set; }
    public string? Notes { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public WatchlistItemAttributes? Attributes { get; private set; }

    private WatchlistItem(
        WatchlistItemId id, 
        WatchlistId watchlistId, 
        TitleId titleId, 
        WatchlistItemStatus status, 
        int progress, 
        string? tags, 
        string? notes, 
        DateTime createdAt)
    {
        Id = id;
        WatchlistId = watchlistId;
        TitleId = titleId;
        Status = status;
        Progress = progress;
        Tags = tags;
        Notes = notes;
        CreatedAt = createdAt;
    }

    public static WatchlistItem New(
        WatchlistItemId id,
        WatchlistId watchlistId,
        TitleId titleId,
        WatchlistItemStatus status,
        int progress,
        string? tags,
        string? notes,
        WatchlistItemAttributes? attributes)
        => new(
            id,
            watchlistId,
            titleId,
            status,
            progress,
            tags,
            notes,
            DateTime.UtcNow)
        {
            Attributes = attributes
        };

    public void Update(
        WatchlistItemStatus status,
        int progress,
        string? tags,
        string? notes,
        WatchlistItemAttributes? attributes)
    {
        Status = status;
        Progress = progress;
        Tags = tags;
        Notes = notes;
        Attributes = attributes;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}