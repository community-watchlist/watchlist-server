using Domain.Titles.Properties;
using LanguageExt;

namespace Application.Common.Interfaces.Repositories.Titles;

public interface ITitlePropertiesRepository
{
    Task<Option<TitleProperties>> GetById(TitlePropertiesId titlePropertiesId, CancellationToken cancellationToken);
    Task<Option<TitleProperties>> GetBySlug(string slug, CancellationToken cancellationToken);
    Task<TitleProperties> Add(TitleProperties titleProperties, CancellationToken cancellationToken);
    Task<TitleProperties> Update(TitleProperties titleProperties, CancellationToken cancellationToken);
    Task SaveChanges(CancellationToken cancellationToken);
}