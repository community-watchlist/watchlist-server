using Domain.Titles;
using Domain.Watchlists;
using Domain.Watchlists.Items;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Watchlists;

public interface IWatchlistItemRepository
{
    Task<IReadOnlyList<WatchlistItem>> GetByWatchlistId(WatchlistId watchlistId, CancellationToken cancellationToken);    Task<Option<WatchlistItem>> GetById(WatchlistItemId watchlistItemId, CancellationToken cancellationToken);
    Task<WatchlistItem> Add(WatchlistItem watchlistItem, CancellationToken cancellationToken);
    Task<WatchlistItem> Update(WatchlistItem watchlistItem, CancellationToken cancellationToken);
    Task Delete(WatchlistItem watchlistItem, CancellationToken cancellationToken);   
    Task SaveChanges(CancellationToken cancellationToken);   
}