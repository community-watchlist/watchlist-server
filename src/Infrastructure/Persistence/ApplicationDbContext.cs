using System.Reflection;
using Domain.Episodes;
using Domain.Episodes.Properties;
using Domain.Episodes.Translations;
using Domain.Genres;
using Domain.Genres.Translations;
using Domain.Languages;
using Domain.Titles;
using Domain.Titles.Poster;
using Domain.Titles.Properties;
using Domain.Titles.Translations;
using Domain.Users;
using Domain.Users.Banner;
using Domain.Users.Picture;
using Domain.Users.UserScores;
using Domain.Watchlists;
using Domain.Watchlists.Banner;
using Domain.Watchlists.Items;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    public DbSet<Language> Languages { get; init; }
    public DbSet<User> Users { get; init; }
    public DbSet<UserPicture> UserPictures { get; init; }
    public DbSet<UserBanner> UserBanners { get; init; }
    public DbSet<Watchlist> Watchlists { get; init; }
    public DbSet<WatchlistBanner> WatchlistBanners { get; init; }
    public DbSet<WatchlistItem> WatchlistItems { get; init; }
    public DbSet<Title> Titles { get; init; }
    public DbSet<TitleProperties> TitleProperties { get; init; }
    public DbSet<TitlePoster> TitlePosters { get; init; }
    public DbSet<UserScoreTitle> UserScoreTitles { get; init; }
    public DbSet<UserScoreEpisode> UserScoreEpisodes { get; init; }
    public DbSet<Genre> Genres { get; init; }
    public DbSet<Episode> Episodes { get; init; }
    public DbSet<TitleGenre> TitleGenres { get; init; }
    public DbSet<GenreTranslation> GenreTranslations { get; init; }
    public DbSet<TitleTranslation> TitleTranslations { get; init; }
    public DbSet<EpisodeTranslation> EpisodeTranslations { get; init; }
    public DbSet<EpisodeProperties> EpisodeProperties { get; init; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}