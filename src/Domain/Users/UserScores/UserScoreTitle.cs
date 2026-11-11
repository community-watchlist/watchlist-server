using Domain.Titles;

namespace Domain.Users.UserScores;

public class UserScoreTitle
{
    public UserId UserId { get; }
    public TitleId TitleId { get; }
    public float Score { get; private set; }

    private UserScoreTitle(UserId userId, TitleId titleId, float score)
    {
        UserId = userId;
        TitleId = titleId;
        Score = score;
    }
    
    public static UserScoreTitle New(
        UserId userId,
        TitleId titleId,
        float score)
    => new(userId, titleId, score);

    public void Update(float score)
    {
        Score = score;
    }
}