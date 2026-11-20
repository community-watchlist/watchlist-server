using Application.Common.Interfaces.Queries.Users;
using Application.Common.Interfaces.Repositories.Users;
using Domain.Titles;
using Domain.Users;
using Domain.Users.UserScores;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Users;

public class UserScoreTitleRepository(ApplicationDbContext context) 
    : IUserScoreTitleQueries, IUserScoreTitleRepository
{
    public async Task<IReadOnlyList<UserScoreTitle>> GetByUserId(UserId userid, CancellationToken cancellationToken)
    {
        var query = context.UserScoreTitles
            .AsNoTracking()
            .Include(x => x.Title)
            .Where(x => x.UserId == userid)
            .ToListAsync(cancellationToken);

        return await query;
    }

    public async Task<IReadOnlyList<UserScoreTitle>> GetByTitleId(TitleId titleid, CancellationToken cancellationToken)
    {
        var query = context.UserScoreTitles
            .AsNoTracking()
            .Include(x => x.User)
            .Where(x => x.TitleId == titleid)
            .ToListAsync(cancellationToken);

        return await query;
    }

    public async Task<Option<UserScoreTitle>> GetByUserAndTitle(UserId userid, TitleId titleid, CancellationToken cancellationToken)
    {
        var entity = context.UserScoreTitles
            .FirstOrDefault(x => x.UserId == userid && x.TitleId == titleid);
        
        return entity ?? Option<UserScoreTitle>.None;
    }

    public async Task<UserScoreTitle> Add(UserScoreTitle userScoreTitle, CancellationToken cancellationToken)
    {
        await context.UserScoreTitles.AddAsync(userScoreTitle);
        return userScoreTitle;
    }

    public async Task<UserScoreTitle> Update(UserScoreTitle userScoreTitle, CancellationToken cancellationToken)
    {
        context.UserScoreTitles.Update(userScoreTitle);
        return userScoreTitle;
    }

    public async Task Delete(UserScoreTitle userScoreTitle, CancellationToken cancellationToken)
    {
        context.UserScoreTitles.Remove(userScoreTitle);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}