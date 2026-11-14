using Domain.Titles;
using Domain.Watchlists;
using Domain.Watchlists.Items;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Watchlists;

public class WatchlistItemConfiguration : IEntityTypeConfiguration<WatchlistItem>
{
    public void Configure(EntityTypeBuilder<WatchlistItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new WatchlistItemId(x));
        
        builder.Property(x => x.WatchlistId)
            .HasConversion(x => x.Value, x => new WatchlistId(x))
            .IsRequired();
        
        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x))
            .IsRequired();
        
        builder.HasIndex(x => new { x.WatchlistId, x.TitleId })
            .IsUnique();
        
        builder.Property(x => x.Status)
            .HasColumnType("varchar(32)")
            .HasConversion(x => x.ToString(), x => WatchlistItemStatus.From(x))
            .IsRequired();
        
        builder.Property(x => x.Progress)
            .IsRequired();
        
        builder.Property(x => x.Tags)
            .HasColumnType("varchar(255)");
        
        builder.Property(x => x.Notes)
            .HasColumnType("varchar(1000)");
        
        builder.Property(x => x.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.Property(x => x.DeletedAt)
            .HasConversion(new DateTimeUtcConverter());

        builder.OwnsOne(x => x.Attributes, attributesBuilder =>
        {
            attributesBuilder.ToJson("attributes");
            
            attributesBuilder.Property(x => x.StartedAt)
                .HasJsonPropertyName("started_at");
            
            attributesBuilder.Property(x => x.FinishedAt)
                .HasJsonPropertyName("finished_at");
        });
        
        builder.HasOne(x => x.Watchlist)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.WatchlistId)
            .HasConstraintName("fk_watchlist_items_watchlist_id")
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Title)
            .WithMany()
            .HasForeignKey(x => x.TitleId)
            .HasConstraintName("fk_watchlist_items_title_id")
            .OnDelete(DeleteBehavior.Restrict);
    }
}