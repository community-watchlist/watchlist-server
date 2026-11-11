using Domain.Users;

namespace Domain.Watchlists;

public class Watchlist
{
    public WatchlistId Id { get; }
    public UserId UserId { get; private set; }
    public bool IsPublic { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Watchlist(WatchlistId id, UserId userId, bool isPublic, DateTime createdAt)
    {
        Id = id;
        UserId = userId;
        IsPublic = isPublic;
        CreatedAt = createdAt;
    }
    
    public static Watchlist New(
        WatchlistId id, 
        UserId userId, 
        bool isPublic)
    => new(id, userId, isPublic, DateTime.UtcNow);
    
    public void Update(
        bool isPublic)
    {
        IsPublic = isPublic;
    }
}