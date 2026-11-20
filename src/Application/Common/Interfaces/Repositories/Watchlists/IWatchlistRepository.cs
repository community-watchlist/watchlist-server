using Domain.Users;
using Domain.Watchlists;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Watchlists;

public interface IWatchlistRepository
{
    Task<Option<Watchlist>> GetById(WatchlistId id, CancellationToken cancellationToken);
    Task<Option<Watchlist>> GetByUserId(UserId userId, CancellationToken cancellationToken);
    Task<Watchlist> Add(Watchlist watchlist, CancellationToken cancellationToken);
    Task<Watchlist> Update(Watchlist watchlist, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}