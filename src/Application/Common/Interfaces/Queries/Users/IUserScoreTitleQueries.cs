using Domain.Titles;
using Domain.Users;
using Domain.Users.UserScores;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Users;

public interface IUserScoreTitleQueries
{
    Task<IReadOnlyList<UserScoreTitle>> GetByUserId(UserId userid, CancellationToken cancellationToken);
    Task<IReadOnlyList<UserScoreTitle>> GetByTitleId(TitleId titleid, CancellationToken cancellationToken);
}