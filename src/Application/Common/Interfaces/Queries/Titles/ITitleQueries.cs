using Domain.Titles;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Titles;

public interface ITitleQueries
{
    Task<IReadOnlyList<Title>> GetAll(TitleType? type, CancellationToken cancellationToken);
    Task<IReadOnlyList<Title>> GetAllBySearch(string query, TitleType? type, CancellationToken cancellationToken);
    Task<IReadOnlyList<Title>> GetFiltered(
        TitleType? type,
        string? title,
        string? overview,
        TitleReleaseStatus? releaseStatus,
        DateTime? createdAtFrom,
        DateTime? createdAtTo,
        CancellationToken cancellationToken);
    Task<Option<Title>> GetById(TitleId titleId, TitleType? type, CancellationToken cancellationToken);
    Task<Option<Title>> GetByIdWithDetails(TitleId titleId, TitleType? type, CancellationToken cancellationToken);
}