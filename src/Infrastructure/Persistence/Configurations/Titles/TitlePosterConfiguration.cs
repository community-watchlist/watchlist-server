using Domain.Titles;
using Domain.Titles.Poster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Titles;

public class TitlePosterConfiguration : IEntityTypeConfiguration<TitlePoster>
{
    public void Configure(EntityTypeBuilder<TitlePoster> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new TitlePosterId(x));

        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x))
            .IsRequired();
        
        builder.HasIndex(x => x.TitleId)
            .IsUnique();
        
        builder.HasOne(x => x.Title)
            .WithOne()
            .HasForeignKey<TitlePoster>(x => x.TitleId)
            .HasConstraintName("fk_title_poster_title_id")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.OriginalFileName)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(x => x.FileUrl)
            .HasColumnType("varchar(2048)")
            .IsRequired();
    }
}