using Domain.Users;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Users;

public interface IUserQueries
{
    Task<IReadOnlyList<User>> GetAll(CancellationToken cancellationToken);
    Task<Option<User>> GetById(UserId id, CancellationToken cancellationToken);
    Task<Option<User>> GetByUsername(string username, CancellationToken cancellationToken);
}