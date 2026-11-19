using Application.Common.Interfaces.Queries.Users;
using Application.Common.Interfaces.Repositories.Users;
using Domain.Users;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Users;

public class UserRepository(ApplicationDbContext context) : IUserQueries, IUserRepository
{
    public async Task<IReadOnlyList<User>> GetAll(CancellationToken cancellationToken)
    {
        return await context.Users.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Option<User>> GetById(UserId id, CancellationToken cancellationToken)
    {
        var entity = await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return entity ?? Option<User>.None;
    }

    public async Task<Option<User>> GetByClerkId(string clerkId, CancellationToken cancellationToken)
    {
        var entity = await context.Users.FirstOrDefaultAsync(x => x.ClerkId == clerkId, cancellationToken);
        return entity ?? Option<User>.None;
    }

    public async Task<Option<User>> GetByUsername(string username, CancellationToken cancellationToken)
    {
        var entity = await context.Users.FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
        return entity ?? Option<User>.None;
    }

    public async Task<User> Add(User user, CancellationToken cancellationToken)
    {
        await context.Users.AddAsync(user, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> Update(User user, CancellationToken cancellationToken)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task Delete(User user, CancellationToken cancellationToken)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
    }
}