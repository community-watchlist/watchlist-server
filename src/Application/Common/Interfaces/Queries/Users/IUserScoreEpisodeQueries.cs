using Domain.Episodes;
using Domain.Users;
using Domain.Users.UserScores;

namespace Application.Common.Interfaces.Queries.Users;

public interface IUserScoreEpisodeQueries
{
    Task<IReadOnlyList<UserScoreEpisode>> GetAllByUserId (UserId userId, CancellationToken cancellationToken);
    Task<IReadOnlyList<UserScoreEpisode>> GetAllByEpisodeId(EpisodeId episodeId, CancellationToken cancellationToken);
}