using Domain.Users;
using Domain.Watchlists;
using Domain.Watchlists.Banner;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Watchlists;

public interface IWatchlistBannerRepository
{
    Task<Option<WatchlistBanner>> GetByWatchlistId(WatchlistId watchlistId, CancellationToken cancellationToken);
    Task<WatchlistBanner> Add(WatchlistBanner watchlistBanner, CancellationToken cancellationToken);
    Task<WatchlistBanner> Update(WatchlistBanner watchlistBanner, CancellationToken cancellationToken);
    Task Delete(WatchlistBanner watchlistBanner, CancellationToken cancellationToken);   
    Task SaveChanges(CancellationToken cancellationToken);
}