using Domain.Episodes;
using Domain.Episodes.Translations;
using Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Episodes;

public class EpisodeTranslationConfiguration : IEntityTypeConfiguration<EpisodeTranslation>
{
    public void Configure(EntityTypeBuilder<EpisodeTranslation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EpisodeTranslationId(x));
        
        builder.Property(x => x.EpisodeId)
            .HasConversion(x => x.Value, x => new EpisodeId(x))
            .IsRequired();
        
        builder.HasOne(x => x.Episode)
            .WithMany(x => x.EpisodeTranslations)
            .HasForeignKey(x => x.EpisodeId)
            .HasConstraintName("fk_episode_translation_episode_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.LanguageCode)
            .HasConversion(x => x.ToString(), x => LanguageCode.From(x))
            .IsRequired();
        
        builder.HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.LanguageCode)
            .HasConstraintName("fk_episode_translation_language_code")
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => new { x.EpisodeId, x.LanguageCode })
            .IsUnique();

        builder.Property(x => x.TranslatedTitle)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(x => x.Overview)
            .HasColumnType("varchar(2047)");
    }
}