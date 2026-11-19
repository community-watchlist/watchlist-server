using Domain.Users;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Users;

public interface IUserRepository
{
    Task<Option<User>> GetById(UserId id, CancellationToken cancellationToken);
    Task<Option<User>> GetByClerkId(string clerkId, CancellationToken cancellationToken);
    Task<Option<User>> GetByUsername(string username, CancellationToken cancellationToken);
    Task<User> Add(User user, CancellationToken cancellationToken);
    Task<User> Update(User user, CancellationToken cancellationToken);
    Task Delete(User user, CancellationToken cancellationToken);
}