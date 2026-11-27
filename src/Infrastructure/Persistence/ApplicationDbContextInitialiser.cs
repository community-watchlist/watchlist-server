using Infrastructure.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence;

public class ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
    ApplicationDbContext context,
    LanguageSeeder languageSeeder)
{
    public async Task InitialiseAsync()
    {
        try
        {
            await context.Database.MigrateAsync();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An error occurred during initialisation.");
            throw;
        }
    }
    
    public async Task SeedAsync()
    {
        try
        {
            await languageSeeder.SeedAsync();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An error occurred during seeding.");
            throw;
        }
    }
}