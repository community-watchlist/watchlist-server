using Domain.Episodes;
using Domain.Episodes.Attributes;
using Domain.Titles;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Episodes;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EpisodeId(x));

        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x));
        
        builder.HasOne(x => x.Title)
            .WithMany()
            .HasForeignKey(x => x.TitleId)
            .HasConstraintName("fk_episodes_title_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.Provider)
            .HasColumnType("varchar(32)")
            .IsRequired();

        builder.Property(x => x.ExternalId)
            .HasColumnType("varchar(64)")
            .IsRequired();
        
        builder.HasIndex(x => new { x.Provider, x.ExternalId })
            .IsUnique();
        
        builder.Property(x => x.OriginalTitle)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(x => x.Overview)
            .HasColumnType("varchar(2047)");
        
        builder.Property(x => x.Position)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.Property(x => x.DeletedAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.Property(x => x.FetchedAt)
            .HasConversion(new DateTimeUtcConverter());

        builder.OwnsOne<EpisodeAttributes>(x => x.Attributes, attributesBuilder =>
        {
            attributesBuilder.ToJson("attributes");
            
            attributesBuilder.Property(x => x.Runtime).HasJsonPropertyName("runtime");
            attributesBuilder.Property(x => x.PosterUrl).HasJsonPropertyName("poster_url");
            attributesBuilder.Property(x => x.ReleaseDate).HasJsonPropertyName("release_date");
            attributesBuilder.Property(x => x.ExternalScore).HasJsonPropertyName("external_score");
            attributesBuilder.Property(x => x.ExternalScoreCount).HasJsonPropertyName("external_score_count");
            attributesBuilder.OwnsMany<Link>(x => x.AlternativeLinks, alternativeLinksAttributesBuilder =>
            {
                alternativeLinksAttributesBuilder.ToJson("alternative_links");
                
                alternativeLinksAttributesBuilder.Property(x => x.SiteName).HasJsonPropertyName("site_name");
                alternativeLinksAttributesBuilder.Property(x => x.Url)
                    .HasJsonPropertyName("url")
                    .IsRequired();
            });
            attributesBuilder.OwnsMany<Link>(x => x.StreamingLinks, streamingLinksAttributesBuilder =>
            {
                streamingLinksAttributesBuilder.ToJson("streaming_links");
                
                streamingLinksAttributesBuilder.Property(x => x.SiteName).HasJsonPropertyName("site_name");
                streamingLinksAttributesBuilder.Property(x => x.Url)
                    .HasJsonPropertyName("url")
                    .IsRequired();
            });

        });
    }
}