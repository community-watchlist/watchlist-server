using Domain.Titles;
using Domain.Titles.Properties;
using LanguageExt;

namespace Application.Common.Interfaces.Queries.Titles;

public interface ITitlePropertiesQueries
{
    Task<Option<TitleProperties>> GetByTitleId(TitleId titleId, CancellationToken cancellationToken);
}