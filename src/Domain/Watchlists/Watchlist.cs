using Domain.Users;
using Domain.Watchlists.Banner;
using Domain.Watchlists.Items;

namespace Domain.Watchlists;

public class Watchlist
{
    public WatchlistId Id { get; }
    public UserId UserId { get; private set; }
    public bool IsPublic { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User? User { get; } = null;
    public WatchlistBanner? Banner { get; } = null;
    
    public ICollection<WatchlistItem>? Items { get; private set; } = null;
    
    private Watchlist(WatchlistId id, UserId userId, bool isPublic, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        IsPublic = isPublic;
        CreatedAt = createdAt;
    }
    
    public static Watchlist New(
        WatchlistId id, 
        UserId userId)
    => new(id, userId, true, DateTime.UtcNow);
    
    public void Update(
        bool isPublic)
    {
        IsPublic = isPublic;
    }
}