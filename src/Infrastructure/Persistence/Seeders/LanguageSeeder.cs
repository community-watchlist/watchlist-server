using Domain.Languages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Seeders;

public class LanguageSeeder(ApplicationDbContext context)
{
    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var defaultLanguages = new List<Language>
        {
            Language.New(LanguageCode.English, "English"),
            Language.New(LanguageCode.Ukrainian, "Українська"),
            Language.New(LanguageCode.Spanish, "Español"),
            Language.New(LanguageCode.Japanese, "日本語")
        };

        var existingCodes = await context.Languages
            .Select(x => x.Code)
            .ToListAsync(cancellationToken);

        var missingLanguages = defaultLanguages
            .Where(x => !existingCodes.Contains(x.Code))
            .ToList();

        if (missingLanguages.Count > 0)
        {
            await context.Languages.AddRangeAsync(missingLanguages, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}