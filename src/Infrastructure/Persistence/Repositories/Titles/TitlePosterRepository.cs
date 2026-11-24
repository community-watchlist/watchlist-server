using Application.Common.Interfaces.Repositories.Titles;
using Domain.Titles;
using Domain.Titles.Poster;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Titles;

public class TitlePosterRepository(ApplicationDbContext context) : ITitlePosterRepository
{
    public async Task<Option<TitlePoster>> GetByTitleId(TitleId titleId, CancellationToken cancellationToken)
    {
        var entity = await context.TitlePosters
            .FirstOrDefaultAsync(x => x.TitleId == titleId, cancellationToken);
        return entity ?? Option<TitlePoster>.None;
    }

    public async Task<TitlePoster> Add(TitlePoster titlePoster, CancellationToken cancellationToken)
    {
        await context.TitlePosters.AddAsync(titlePoster, cancellationToken);
        return titlePoster;      
    }

    public async Task<TitlePoster> Update(TitlePoster titlePoster, CancellationToken cancellationToken)
    {
        context.TitlePosters.Update(titlePoster);
        return titlePoster;     
    }

    public async Task Delete(TitlePoster titlePoster, CancellationToken cancellationToken)
    {
        context.TitlePosters.Remove(titlePoster);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);     
    }
}