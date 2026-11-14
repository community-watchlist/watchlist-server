using Domain.Titles;
using Domain.Titles.Attributes;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Titles;

public class TitleConfiguration : IEntityTypeConfiguration<Title>
{
    public void Configure(EntityTypeBuilder<Title> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TitleId(x));

        builder.Property(x => x.Type)
            .HasColumnType("varchar(16)")
            .HasConversion(x => x.ToString(), x => TitleType.From(x))
            .IsRequired();

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

        builder.Property(x => x.TitleReleaseStatus)
            .HasColumnType("varchar(32)")
            .HasConversion(x => x.ToString(), x => TitleReleaseStatus.From(x))
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

        builder.OwnsOne<TitleAttributes>(x => x.Attributes, attributesBuilder =>
        {
            attributesBuilder.ToJson("attributes");

            attributesBuilder.Property(x => x.Rating)
                .HasConversion(x => x.ToString(), x => TitleRating.From(x))
                .IsRequired()
                .HasJsonPropertyName("rating");
            attributesBuilder.Property(x => x.BackdropImageUrl).HasJsonPropertyName("backdrop_image_url");
            attributesBuilder.Property(x => x.OriginalLanguage).HasJsonPropertyName("original_language");
            attributesBuilder.Property(x => x.ExternalScore).HasJsonPropertyName("external_score");
            attributesBuilder.Property(x => x.ExternalScoreCount).HasJsonPropertyName("external_score_count");
            attributesBuilder.Property(x => x.ExternalPopularity).HasJsonPropertyName("external_popularity");
            attributesBuilder.Property(x => x.ReleaseDate).HasJsonPropertyName("release_date");
            attributesBuilder.Property(x => x.Runtime).HasJsonPropertyName("runtime");
            attributesBuilder.Property(x => x.Episodes).HasJsonPropertyName("episodes");
            attributesBuilder.Property(x => x.MediaType).HasJsonPropertyName("media_type");
            attributesBuilder.Property(x => x.AverageRuntime).HasJsonPropertyName("average_runtime");
            attributesBuilder.OwnsOne<AiredData>(x => x.Aired, airedAttributesBuilder =>
            {
                airedAttributesBuilder.ToJson("aired");
                
                airedAttributesBuilder.Property(x => x.From).HasJsonPropertyName("from");
                airedAttributesBuilder.Property(x => x.To).HasJsonPropertyName("to");
            });
            attributesBuilder.OwnsOne<BroadcastData>(x => x.Broadcast, broadcastAttributesBuilder =>
            {
                broadcastAttributesBuilder.ToJson("broadcast");
                
                broadcastAttributesBuilder.Property(x => x.WeekDay)
                    .HasJsonPropertyName("weekday")
                    .IsRequired();
                broadcastAttributesBuilder.Property(x => x.Time).HasJsonPropertyName("time");
            });
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
            attributesBuilder.OwnsMany<Link>(x => x.SocialLinks, socialLinksAttributesBuilder =>
            {
                socialLinksAttributesBuilder.ToJson("social_links");
                
                socialLinksAttributesBuilder.Property(x => x.SiteName).HasJsonPropertyName("site_name");
                socialLinksAttributesBuilder.Property(x => x.Url)
                    .HasJsonPropertyName("url")
                    .IsRequired();
            });
            attributesBuilder.OwnsMany<Relation>(x => x.Relations, relationAttributesBuilder =>
            {
                relationAttributesBuilder.ToJson("relations");

                relationAttributesBuilder.Property(x => x.TitleRelationType)
                    .HasConversion(x => x.ToString(), x => TitleRelationType.From(x))
                    .HasJsonPropertyName("relation_type")
                    .IsRequired();
                relationAttributesBuilder.Property(x => x.OriginalTitle).HasJsonPropertyName("original_title");
                relationAttributesBuilder.Property(x => x.ExternalId).HasJsonPropertyName("external_id");
            });
        });
    }
}