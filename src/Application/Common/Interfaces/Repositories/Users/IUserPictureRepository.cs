using Domain.Users;
using Domain.Users.Picture;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Users;

public interface IUserPictureRepository
{
    Task<Option<UserPicture>> GetByUserId(UserId userid, CancellationToken cancellationToken);
    Task<UserPicture> Add(UserPicture userPicture, CancellationToken cancellationToken);
    Task<UserPicture> Update(UserPicture userPicture, CancellationToken cancellationToken);
    Task Delete(UserPicture userPicture, CancellationToken cancellationToken);   
    Task SaveChanges(CancellationToken cancellationToken);
}