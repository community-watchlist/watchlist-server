using Application.Common.Interfaces.Queries.Languages;
using Application.Common.Interfaces.Queries.Users;
using Application.Common.Interfaces.Repositories.Users;
using Infrastructure.Persistence.Repositories.Languages;
using Infrastructure.Persistence.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure.Persistence;

public static class ConfigurePersistenceServices
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<ApplicationDbContext>(options => options
            .UseNpgsql(
                dataSource,
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            .UseSnakeCaseNamingConvention()
            .ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning);
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning);
            }));

        services.AddScoped<ApplicationDbContextInitialiser>();
        services.AddRepositories();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<LanguageRepository>();
        services.AddScoped<ILanguageQueries>(provider => provider.GetRequiredService<LanguageRepository>());
        services.AddScoped<UserRepository>();
        services.AddScoped<IUserQueries>(provider => provider.GetRequiredService<UserRepository>());
        services.AddScoped<IUserRepository>(provider => provider.GetRequiredService<UserRepository>());
        services.AddScoped<UserPictureRepository>();
        services.AddScoped<IUserPictureRepository>(provider => provider.GetRequiredService<UserPictureRepository>());
        services.AddScoped<IUserBannerRepository>();
        services.AddScoped<UserBannerRepository>(provider => provider.GetRequiredService<UserBannerRepository>());
        //TODO add future repositories
    }
}