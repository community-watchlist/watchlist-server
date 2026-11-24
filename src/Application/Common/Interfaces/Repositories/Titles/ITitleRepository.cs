using Domain.Titles;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Titles;

public interface ITitleRepository
{
    Task<Option<Title>> GetById(TitleId titleId, TitleType? type, CancellationToken cancellationToken);
    Task<Option<Title>> GetByExternalId(string externalId, string provider, CancellationToken cancellationToken);
    Task<Title> Add(Title title, CancellationToken cancellationToken);
    Task<Title> Update(Title title, CancellationToken cancellationToken);
    Task Delete(Title title, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}