using Domain.Users;
using Domain.Users.Banner;
using Domain.Users.Picture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Users;

public class UserPictureConfiguration : IEntityTypeConfiguration<UserPicture>
{
    public void Configure(EntityTypeBuilder<UserPicture> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserPictureId(x));
        
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
            .WithOne(x => x.Picture)
            .HasForeignKey<UserBanner>(x => x.UserId)
            .HasConstraintName("fk_user_pictures_user_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}