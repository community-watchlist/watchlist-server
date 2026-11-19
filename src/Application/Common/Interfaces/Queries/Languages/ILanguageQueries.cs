using Domain.Languages;

namespace Application.Common.Queries.Languages;

public interface ILanguageQueries
{
    Task<IReadOnlyList<Language>> GetAll(CancellationToken cancellationToken);
}