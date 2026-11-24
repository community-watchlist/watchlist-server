using Application.Common.Interfaces.Queries.Genres;
using Application.Common.Interfaces.Repositories.Genres;
using Domain.Genres;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Genres;

public class GenreRepository(ApplicationDbContext context) : IGenreRepository, IGenreQueries
{
    public async Task<IReadOnlyList<Genre>> GetAll(CancellationToken cancellationToken)
    {
        return await context.Genres
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Option<Genre>> GetById(GenreId genreId, CancellationToken cancellationToken)
    {
        return await context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == genreId, cancellationToken);
    }

    public async Task<Option<Genre>> GetByName(string name, CancellationToken cancellationToken)
    {
        return await context.Genres
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OriginalName.ToLower().Contains(name.Trim().ToLower()), cancellationToken);
    }

    public async Task<Genre> Add(Genre genre, CancellationToken cancellationToken)
    {
        await context.Genres.AddAsync(genre, cancellationToken);
        return genre;
    }

    public async Task<Genre> Update(Genre genre, CancellationToken cancellationToken)
    {
        context.Genres.Update(genre);
        return genre;
    }

    public async Task Delete(Genre genre, CancellationToken cancellationToken)
    {
        context.Genres.Remove(genre);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}