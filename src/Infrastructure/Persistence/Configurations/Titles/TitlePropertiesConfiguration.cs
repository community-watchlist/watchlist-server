using Domain.Titles;
using Domain.Titles.Properties;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Titles;

public class TitlePropertiesConfiguration : IEntityTypeConfiguration<TitleProperties>
{
    public void Configure(EntityTypeBuilder<TitleProperties> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TitlePropertiesId(x));

        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x))
            .IsRequired();
        
        builder.HasIndex(x => x.TitleId)
            .IsUnique();
        
        builder.HasOne(x => x.Title)
            .WithOne()
            .HasForeignKey<TitleProperties>(x => x.TitleId)
            .HasConstraintName("fk_title_properties_title_id")
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
        
        builder.Property(x => x.UpdatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
    }
}