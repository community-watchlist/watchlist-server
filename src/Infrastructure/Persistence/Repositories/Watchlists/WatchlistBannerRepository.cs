using Application.Common.Interfaces.Repositories.Watchlists;
using Domain.Users;
using Domain.Watchlists;
using Domain.Watchlists.Banner;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Watchlists;

public class WatchlistBannerRepository(ApplicationDbContext context) : IWatchlistBannerRepository
{
    public async Task<Option<WatchlistBanner>> GetByWatchlistId(WatchlistId watchlistId, CancellationToken cancellationToken)
    {
        var entity = await context.WatchlistBanners
            .FirstOrDefaultAsync(x => x.WatchlistId == watchlistId);
        return entity ?? Option<WatchlistBanner>.None;
    }

    public async Task<WatchlistBanner> Add(WatchlistBanner watchlistBanner, CancellationToken cancellationToken)
    {
        await context.WatchlistBanners.AddAsync(watchlistBanner, cancellationToken);
        return watchlistBanner;
    }

    public async Task<WatchlistBanner> Update(WatchlistBanner watchlistBanner, CancellationToken cancellationToken)
    {
        context.WatchlistBanners.Update(watchlistBanner);
        return watchlistBanner;
    }

    public async Task Delete(WatchlistBanner watchlistBanner, CancellationToken cancellationToken)
    {
        context.WatchlistBanners.Remove(watchlistBanner);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);   
    }
}