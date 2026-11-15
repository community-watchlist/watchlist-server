using Domain.Episodes;
using Domain.Episodes.Properties;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Episodes;

public class EpisodePropertiesConfiguration : IEntityTypeConfiguration<EpisodeProperties>
{
    public void Configure(EntityTypeBuilder<EpisodeProperties> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new EpisodePropertiesId(x));

        builder.Property(x => x.EpisodeId)
            .HasConversion(x => x.Value, x => new EpisodeId(x))
            .IsRequired();
        
        builder.HasIndex(x => x.EpisodeId)
            .IsUnique();
        
        builder.HasOne(x => x.Episode)
            .WithOne()
            .HasForeignKey<EpisodeProperties>(x => x.EpisodeId)
            .HasConstraintName("fk_episode_properties_episode_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(x => x.Slug)
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.HasIndex(x => x.Slug)
            .IsUnique();

        builder.Property(x => x.ScoreAverage)
            .HasColumnType("real");

        builder.Property(x => x.ScoreCount)
            .IsRequired();
        
        builder.Property(x => x.Views)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasConversion(new DateTimeUtcConverter());
    }
}