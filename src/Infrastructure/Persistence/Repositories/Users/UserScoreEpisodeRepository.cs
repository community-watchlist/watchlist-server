using Application.Common.Interfaces.Queries.Users;
using Application.Common.Interfaces.Repositories.Users;
using Domain.Episodes;
using Domain.Users;
using Domain.Users.UserScores;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Users;

public class UserScoreEpisodeRepository(ApplicationDbContext context) 
    : IUserScoreEpisodeQueries, IUserScoreEpisodeRepository
{
    public async Task<IReadOnlyList<UserScoreEpisode>> GetAllByUserId(UserId userId, CancellationToken cancellationToken)
    {
        var query = context.UserScoreEpisodes
            .AsNoTracking()
            .Include(x => x.Episode)
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);

        return await query;
    }

    public async Task<IReadOnlyList<UserScoreEpisode>> GetAllByEpisodeId(EpisodeId episodeId, CancellationToken cancellationToken)
    {
        var query = context.UserScoreEpisodes
            .AsNoTracking()
            .Include(x => x.User)
            .Where(x => x.EpisodeId == episodeId)
            .ToListAsync(cancellationToken);

        return await query;
    }

    public async Task<Option<UserScoreEpisode>> GetByUserAndEpisode(UserId userId, EpisodeId episodeId, CancellationToken cancellationToken)
    {
        var entity = context.UserScoreEpisodes
            .FirstOrDefault(x => x.UserId == userId && x.EpisodeId == episodeId);
        
        return entity ?? Option<UserScoreEpisode>.None;
    }

    public async Task<UserScoreEpisode> Add(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken)
    {
        await context.UserScoreEpisodes.AddAsync(userScoreEpisode, cancellationToken);
        return userScoreEpisode;
    }

    public async Task<UserScoreEpisode> Update(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken)
    {
        context.UserScoreEpisodes.Update(userScoreEpisode);
        return userScoreEpisode;
    }

    public async Task Delete(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken)
    {
        context.UserScoreEpisodes.Remove(userScoreEpisode);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}