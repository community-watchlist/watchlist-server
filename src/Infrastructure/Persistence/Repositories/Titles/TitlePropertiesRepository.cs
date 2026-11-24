using Application.Common.Interfaces.Queries.Titles;
using Application.Common.Interfaces.Repositories.Titles;
using Domain.Titles;
using Domain.Titles.Properties;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Titles;

public class TitlePropertiesRepository(ApplicationDbContext context) : ITitlePropertiesRepository, ITitlePropertiesQueries
{
    public async Task<Option<TitleProperties>> GetById(TitlePropertiesId titlePropertiesId, CancellationToken cancellationToken)
    {
        var entity = await context.TitleProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == titlePropertiesId, cancellationToken);
        return entity ?? Option<TitleProperties>.None;
    }

    public async Task<Option<TitleProperties>> GetBySlug(string slug, CancellationToken cancellationToken)
    {
        var entity = await context.TitleProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Slug.Equals(slug), cancellationToken);
        return entity ?? Option<TitleProperties>.None;
    }
    
    public async Task<Option<TitleProperties>> GetByTitleId(TitleId titleId, CancellationToken cancellationToken)
    {
        var entity = await context.TitleProperties
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.TitleId == titleId, cancellationToken);
        return entity ?? Option<TitleProperties>.None;
    }

    public async Task<TitleProperties> Add(TitleProperties titleProperties, CancellationToken cancellationToken)
    {
        await context.TitleProperties.AddAsync(titleProperties, cancellationToken);
        return titleProperties;
    }

    public async Task<TitleProperties> Update(TitleProperties titleProperties, CancellationToken cancellationToken)
    {
        context.TitleProperties.Update(titleProperties);
        return titleProperties;
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync(cancellationToken);
    }
}