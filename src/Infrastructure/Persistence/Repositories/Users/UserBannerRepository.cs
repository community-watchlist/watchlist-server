using Application.Common.Interfaces.Repositories.Users;
using Domain.Users;
using Domain.Users.Banner;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Users;

public class UserBannerRepository(ApplicationDbContext context) : IUserBannerRepository
{
    public async Task<Option<UserBanner>> GetByUserId(UserId userid, CancellationToken cancellationToken)
    {
        var entity = await context.UserBanners
            .FirstOrDefaultAsync(x => x.UserId == userid);
        return entity ?? Option<UserBanner>.None;
    }

    public async Task<UserBanner> Add(UserBanner userBanner, CancellationToken cancellationToken)
    {
        await context.UserBanners.AddAsync(userBanner, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return userBanner;      
    }

    public async Task<UserBanner> Update(UserBanner userBanner, CancellationToken cancellationToken)
    {
        context.UserBanners.Update(userBanner);
        await context.SaveChangesAsync(cancellationToken);
        return userBanner;     
    }

    public async Task Delete(UserBanner userBanner, CancellationToken cancellationToken)
    {
        context.UserBanners.Remove(userBanner);
        await context.SaveChangesAsync(cancellationToken);     
    }
}