using Domain.Users;
using Domain.Watchlists;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Watchlists;

public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
{
    public void Configure(EntityTypeBuilder<Watchlist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new WatchlistId(x));
        
        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x))
            .IsRequired();
        
        builder.Property(x => x.IsPublic)
            .IsRequired();
        
        builder.Property(x => x.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();
        
        builder.HasOne(x => x.User)
            .WithOne(x => x.Watchlist)
            .HasForeignKey<Watchlist>(x => x.UserId)
            .HasConstraintName("fk_watchlist_user_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}