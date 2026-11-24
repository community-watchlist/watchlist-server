using Domain.Genres;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Genres;

public interface IGenreRepository
{
    Task<Option<Genre>> GetById(GenreId genreId, CancellationToken cancellationToken);
    Task<Option<Genre>> GetByName(string name, CancellationToken cancellationToken);
    Task<Genre> Add(Genre genre, CancellationToken cancellationToken);
    Task<Genre> Update(Genre genre, CancellationToken cancellationToken);
    Task Delete(Genre genre, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}