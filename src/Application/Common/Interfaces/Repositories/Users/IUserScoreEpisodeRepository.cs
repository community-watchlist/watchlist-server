using Domain.Episodes;
using Domain.Users;
using Domain.Users.UserScores;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Users;

public interface IUserScoreEpisodeRepository
{
    Task<Option<UserScoreEpisode>> GetByUserAndEpisode(
        UserId userId,
        EpisodeId episodeId,
        CancellationToken cancellationToken);
    Task<UserScoreEpisode> Add(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken);
    Task<UserScoreEpisode> Update(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken);
    Task Delete(UserScoreEpisode userScoreEpisode, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}