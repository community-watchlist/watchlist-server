using Domain.Users;
using Domain.Users.Banner;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Users;

public interface IUserBannerRepository
{
    Task<Option<UserBanner>> GetByUserId(UserId userid, CancellationToken cancellationToken);
    Task<UserBanner> Add(UserBanner userBanner, CancellationToken cancellationToken);
    Task<UserBanner> Update(UserBanner userBanner, CancellationToken cancellationToken);
    Task Delete(UserBanner userBanner, CancellationToken cancellationToken);   
    Task SaveChanges(CancellationToken cancellationToken);
}