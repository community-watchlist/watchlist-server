using Domain.Episodes;

namespace Domain.Users.UserScores;

public class UserScoreEpisode
{
    public UserId UserId { get; }
    public EpisodeId EpisodeId { get; }
    public float Score { get; private set; }

    private UserScoreEpisode(UserId userId, EpisodeId episodeId, float score)
    {
        UserId = userId;
        EpisodeId = episodeId;
        Score = score;
    }

    public static UserScoreEpisode New(
        UserId userId, 
        EpisodeId episodeId,
        float score)
        => new(userId, episodeId, score);

    public void Update(float score)
    {
        Score = score;
    }
}