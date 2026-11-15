using Domain.Languages;
using Domain.Titles;
using Domain.Titles.Translations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Titles;

public class TitleTranslationConfiguration : IEntityTypeConfiguration<TitleTranslation>
{
    public void Configure(EntityTypeBuilder<TitleTranslation> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TitleTranslationId(x));
        
        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x))
            .IsRequired();
        
        builder.HasOne(x => x.Title)
            .WithMany(x => x.TitleTranslations)
            .HasForeignKey(x => x.TitleId)
            .HasConstraintName("fk_title_translation_title_id")
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.LanguageCode)
            .HasConversion(x => x.ToString(), x => LanguageCode.From(x))
            .IsRequired();
        
        builder.HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.LanguageCode)
            .HasConstraintName("fk_title_translation_language_code")
            .OnDelete(DeleteBehavior.Restrict);
            
        builder.HasIndex(x => new { x.TitleId, x.LanguageCode })
            .IsUnique();

        builder.Property(x => x.TranslatedTitle)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(x => x.Overview)
            .HasColumnType("varchar(2047)");
    }
}