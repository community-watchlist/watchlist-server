using Domain.Watchlists;
using Domain.Watchlists.Banner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Watchlists;

public class WatchlistBannerConfiguration : IEntityTypeConfiguration<WatchlistBanner>
{
    public void Configure(EntityTypeBuilder<WatchlistBanner> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new WatchlistBannerId(x));
        
        builder.Property(x => x.WatchlistId)
            .HasConversion(x => x.Value, x => new WatchlistId(x))
            .IsRequired();
        
        builder.Property(x => x.OriginalFileName)
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.Property(x => x.FileUrl)
            .HasColumnType("varchar(2048)")
            .IsRequired();
        
        builder.HasOne(x => x.Watchlist)
            .WithOne(x => x.Banner)
            .HasForeignKey<WatchlistBanner>(x => x.WatchlistId)
            .HasConstraintName("fk_watchlist_banners_watchlist_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}