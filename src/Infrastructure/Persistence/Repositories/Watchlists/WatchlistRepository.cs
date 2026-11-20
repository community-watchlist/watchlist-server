using Application.Common.Interfaces.Queries.Watchlists;
using Application.Common.Interfaces.Repositories.Watchlists;
using Domain.Users;
using Domain.Watchlists;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Watchlists;

public class WatchlistRepository(ApplicationDbContext context) : IWatchlistQueries, IWatchlistRepository
{
    public async Task<Option<Watchlist>> GetById(WatchlistId id, CancellationToken cancellationToken)
    {
        var entity = await context.Watchlists
            .Include(x => x.Banner)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        return entity ?? Option<Watchlist>.None;
    }

    public async Task<Option<Watchlist>> GetByUserId(UserId userId, CancellationToken cancellationToken)
    {
        var entity = await context.Watchlists
            .Include(x => x.Banner)
            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
        
        return entity ?? Option<Watchlist>.None;
    }

    public async Task<Watchlist> Add(Watchlist watchlist, CancellationToken cancellationToken)
    {
        await context.Watchlists.AddAsync(watchlist, cancellationToken);
        return watchlist;
    }

    public async Task<Watchlist> Update(Watchlist watchlist, CancellationToken cancellationToken)
    {
        context.Watchlists.Update(watchlist);
        return watchlist;
    }
    
    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}