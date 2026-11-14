using Domain.Users;
using Domain.Users.Banner;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Users;

public class UserBannerConfiguration : IEntityTypeConfiguration<UserBanner>
{
    public void Configure(EntityTypeBuilder<UserBanner> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserBannerId(x));

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x))
            .IsRequired();

        builder.Property(x => x.OriginalFileName)
            .HasColumnType("varchar(255)")
            .IsRequired();

        builder.Property(x => x.FileUrl)
            .HasColumnType("varchar(2048)")
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithOne(x => x.Banner)
            .HasForeignKey<UserBanner>(x => x.UserId)
            .HasConstraintName("fk_user_banners_user_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}