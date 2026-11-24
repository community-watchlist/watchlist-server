using Domain.Genres;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Genres;

public interface IGenreQueries
{
    Task<IReadOnlyList<Genre>> GetAll(CancellationToken cancellationToken);
    Task<Option<Genre>> GetById(GenreId genreId, CancellationToken cancellationToken);
}