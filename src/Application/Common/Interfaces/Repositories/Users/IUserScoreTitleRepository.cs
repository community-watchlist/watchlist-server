using Domain.Titles;
using Domain.Users;
using Domain.Users.UserScores;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Users;

public interface IUserScoreTitleRepository
{
    Task<Option<UserScoreTitle>> GetByUserAndTitle(
        UserId userid, 
        TitleId titleid, 
        CancellationToken cancellationToken);
    Task<UserScoreTitle> Add(UserScoreTitle userScoreTitle, CancellationToken cancellationToken);
    Task<UserScoreTitle> Update(UserScoreTitle userScoreTitle, CancellationToken cancellationToken);
    Task Delete(UserScoreTitle userScoreTitle, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}