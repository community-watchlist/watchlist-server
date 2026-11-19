using Domain.Watchlists;
using Domain.Watchlists.Items;

namespace Application.Common.Interfaces.Queries.Watchlists;

public interface IWatchlistItemQueries
{
    Task<IReadOnlyList<WatchlistItem>> GetByWatchlistId(WatchlistId watchlistId, CancellationToken cancellationToken);
}