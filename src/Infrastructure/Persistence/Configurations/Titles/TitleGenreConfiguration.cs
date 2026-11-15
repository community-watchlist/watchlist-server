using Domain.Genres;
using Domain.Titles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Titles;

public class TitleGenreConfiguration : IEntityTypeConfiguration<TitleGenre>
{
    public void Configure(EntityTypeBuilder<TitleGenre> builder)
    {
        builder.HasKey(g => new { g.TitleId, g.GenreId });

        builder.Property(g => g.TitleId).HasConversion(x => x.Value, x => new TitleId(x));
        
        builder.HasOne(g => g.Title)
            .WithMany(x => x.TitleGenres)
            .HasForeignKey(g => g.TitleId)
            .HasConstraintName("fk_title_genre_title_id");
        
        builder.Property(g => g.GenreId).HasConversion(x => x.Value, x => new GenreId(x));
        
        builder.HasOne(g => g.Genre)
            .WithMany(x => x.TitleGenres)
            .HasForeignKey(g => g.GenreId)
            .HasConstraintName("fk_title_genre_genre_id");
    }    
}