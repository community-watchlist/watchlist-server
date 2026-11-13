using Domain.Episodes;
using Domain.Users;
using Domain.Users.UserScores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Users;

public class UserScoreEpisodeConfiguration : IEntityTypeConfiguration<UserScoreEpisode>
{
    public void Configure(EntityTypeBuilder<UserScoreEpisode> builder)
    {
        builder.HasKey(x => new { x.UserId, x.EpisodeId });

        builder.Property(x => x.UserId)
            .HasConversion(x => x.Value, x => new UserId(x))
            .IsRequired();

        builder.Property(x => x.EpisodeId)
            .HasConversion(x => x.Value, x => new EpisodeId(x))
            .IsRequired();

        builder.Property(x => x.Score)
            .IsRequired();

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserScoreEpisodes)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("fk_user_score_episodes_user_id")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Episode)
            .WithMany()
            .HasForeignKey(x => x.EpisodeId)
            .HasConstraintName("fk_user_score_episodes_episode_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}