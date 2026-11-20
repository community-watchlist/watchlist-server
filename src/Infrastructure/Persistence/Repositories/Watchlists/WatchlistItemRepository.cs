using Application.Common.Interfaces.Queries.Watchlists;
using Application.Common.Interfaces.Repositories.Watchlists;
using Domain.Watchlists;
using Domain.Watchlists.Items;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Watchlists;

public class WatchlistItemRepository(ApplicationDbContext context) : IWatchlistItemQueries, IWatchlistItemRepository
{
    public async Task<IReadOnlyList<WatchlistItem>> GetAllByWatchlistId(
        WatchlistId watchlistId,
        CancellationToken cancellationToken)
    {
        var query = context.WatchlistItems
            .AsNoTracking()
            .Include(x => x.Title)
            .Where(x => x.WatchlistId == watchlistId)
            .OrderBy(x =>
                x.Status == WatchlistItemStatus.Watching ? 1 :
                x.Status == WatchlistItemStatus.Planned ? 2 :
                x.Status == WatchlistItemStatus.OnHold ? 3 :
                x.Status == WatchlistItemStatus.Completed ? 4 :
                x.Status == WatchlistItemStatus.Dropped ? 5 : 6)
            .ThenBy(x => x.Title.OriginalTitle)
            .ToListAsync(cancellationToken);
        
        return await query;
    }
    
    public async Task<Option<WatchlistItem>> GetById(
        WatchlistItemId id, 
        CancellationToken cancellationToken)
    {
        var entity = await context.WatchlistItems
            .Include(x => x.Title)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity ?? Option<WatchlistItem>.None;
    }

    public async Task<WatchlistItem> Add(WatchlistItem watchlistItem, CancellationToken cancellationToken)
    {
        await context.WatchlistItems.AddAsync(watchlistItem, cancellationToken);
        return watchlistItem;
    }

    public async Task<WatchlistItem> Update(WatchlistItem watchlistItem, CancellationToken cancellationToken)
    {
        context.WatchlistItems.Update(watchlistItem);
        return watchlistItem;
    }

    public async Task Delete(WatchlistItem watchlistItem, CancellationToken cancellationToken)
    {
        context.WatchlistItems.Remove(watchlistItem);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);  
    }
}