namespace Domain.Watchlists.Banner;

public class WatchlistBanner
{
    public WatchlistBannerId Id { get; }
    public WatchlistId WatchlistId { get; private set; }
    public string OriginalFileName { get; private set; }
    public string FileUrl { get; private set; }

    public Watchlist? Watchlist { get; } = null;

    private WatchlistBanner(
        WatchlistBannerId id, 
        WatchlistId watchlistId, 
        string originalFileName, 
        string fileUrl)
    {
        Id = id;
        WatchlistId = watchlistId;
        OriginalFileName = originalFileName;
        FileUrl = fileUrl;
    }
    
    public static WatchlistBanner New(
        WatchlistBannerId id, 
        WatchlistId watchlistId, 
        string originalFilename, 
        string fileUrl)
    => new(id, watchlistId, originalFilename, fileUrl);
    
    public void Update(
        string originalFilename,
        string fileUrl)
    {
        OriginalFileName = originalFilename;
        FileUrl = fileUrl;
    }
}