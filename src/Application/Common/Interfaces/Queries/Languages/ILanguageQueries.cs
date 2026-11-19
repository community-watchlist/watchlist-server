using Domain.Languages;

namespace Application.Common.Interfaces.Queries.Languages;

public interface ILanguageQueries
{
    Task<IReadOnlyList<Language>> GetAll(CancellationToken cancellationToken);
}