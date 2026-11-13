using Domain.Titles;
using Domain.Users;
using Domain.Users.UserScores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Users;

public class UserScoreTitleConfiguration : IEntityTypeConfiguration<UserScoreTitle>
{
    public void Configure(EntityTypeBuilder<UserScoreTitle> builder)
    {
        builder.HasKey(x => new { x.UserId, x.TitleId });

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x))
            .IsRequired();

        builder.Property(x => x.TitleId)
            .HasConversion(x => x.Value, x => new TitleId(x))
            .IsRequired();

        builder.Property(x => x.Score)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserScoreTitles)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_user_score_titles_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Title)
            .WithMany()
            .HasForeignKey(x => x.TitleId)
            .HasConstraintName("fk_user_score_titles_title_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}