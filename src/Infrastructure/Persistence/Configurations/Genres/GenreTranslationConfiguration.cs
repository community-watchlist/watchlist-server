using Domain.Genres;
using Domain.Genres.Translations;
using Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Genres;

public class GenreTranslationConfiguration : IEntityTypeConfiguration<GenreTranslation>
{
    public void Configure(EntityTypeBuilder<GenreTranslation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new GenreTranslationId(x));
        
        builder.Property(x => x.GenreId)
            .HasConversion(x => x.Value, x => new GenreId(x))
            .IsRequired();
        
        builder.HasOne(x => x.Genre)
            .WithMany(x => x.GenreTranslations)
            .HasForeignKey(x => x.GenreId)
            .HasConstraintName("fk_genre_translation_genre_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.LanguageCode)
            .HasConversion(x => x.ToString(), x => LanguageCode.From(x))
            .IsRequired();
        
        builder.HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.LanguageCode)
            .HasConstraintName("fk_genre_translation_language_code")
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => new { x.GenreId, x.LanguageCode })
            .IsUnique();

        builder.Property(x => x.TranslatedName)
            .HasColumnType("varchar(255)")
            .IsRequired();
    }
}