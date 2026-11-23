using Domain.Titles;
using Domain.Titles.Poster;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Titles;

public interface ITitlePosterRepository
{
    Task<Option<TitlePoster>> GetByTitleId(TitleId titleId, CancellationToken cancellationToken);
    Task<TitlePoster> Add(TitlePoster titlePoster, CancellationToken cancellationToken);
    Task<TitlePoster> Update(TitlePoster titlePoster, CancellationToken cancellationToken);
    Task Delete(TitlePoster titlePoster, CancellationToken cancellationToken);   
    Task SaveChanges(CancellationToken cancellationToken);
}