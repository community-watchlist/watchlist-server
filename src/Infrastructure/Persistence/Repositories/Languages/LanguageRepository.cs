using Application.Common.Interfaces.Queries.Languages;
using Domain.Languages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Languages;

public class LanguageRepository(ApplicationDbContext context) : ILanguageQueries
{
    public async Task<IReadOnlyList<Language>> GetAll(CancellationToken cancellationToken)
    {
        return await context.Languages.ToListAsync(cancellationToken);
    }
}