using Domain.Titles;

namespace Domain.Users.UserScores;

public class UserScoreEpisode
{
    public UserId UserId { get; }
    // public EpisodeId EpisodeId { get; }
    public float Score { get; private set; }

    private UserScoreEpisode(UserId userId, float score)
    {
        UserId = userId;
        Score = score;
    }

    public static UserScoreEpisode New(
        UserId userId, 
        float score)
        => new(userId, score);

    public void Update(float score)
    {
        Score = score;
    }
}