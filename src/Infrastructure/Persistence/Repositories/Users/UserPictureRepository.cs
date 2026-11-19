using Application.Common.Interfaces.Queries.Users;
using Application.Common.Interfaces.Repositories.Users;
using Domain.Users;
using Domain.Users.Picture;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Users;

public class UserPictureRepository(ApplicationDbContext context) : IUserPictureRepository
{
    public async Task<Option<UserPicture>> GetByUserId(UserId userid, CancellationToken cancellationToken)
    {
        var entity = await context.UserPictures
            .FirstOrDefaultAsync(x => x.UserId == userid, cancellationToken);
        return entity ?? Option<UserPicture>.None;
    }

    public async Task<UserPicture> Add(UserPicture userPicture, CancellationToken cancellationToken)
    {
        await context.UserPictures.AddAsync(userPicture, cancellationToken);
        return userPicture;       
    }

    public async Task<UserPicture> Update(UserPicture userPicture, CancellationToken cancellationToken)
    {
        context.UserPictures.Update(userPicture);
        return userPicture;      
    }

    public async Task Delete(UserPicture userPicture, CancellationToken cancellationToken)
    {
        context.UserPictures.Remove(userPicture);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);     
    }
}