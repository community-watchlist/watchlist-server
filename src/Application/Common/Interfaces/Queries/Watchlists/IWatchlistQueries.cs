using Domain.Users;
using Domain.Watchlists;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Watchlists;

public interface IWatchlistQueries
{
    Task<Option<Watchlist>> GetById(WatchlistId id, CancellationToken cancellationToken);
    Task<Option<Watchlist>> GetByUserId(UserId userId, CancellationToken cancellationToken);
}