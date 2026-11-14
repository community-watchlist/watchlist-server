namespace Domain.Users.Banner;

public class UserBanner
{
    public UserBannerId Id { get; }
    public UserId UserId { get; private set; }
    public string OriginalFileName { get; private set; }
    public string FileUrl { get; private set; }
    
    public User? User { get; } = null;

     private UserBanner(
        UserBannerId id, 
        UserId userId, 
        string originalFileName, 
        string fileUrl)
    {
        Id = id;
        UserId = userId;
        OriginalFileName = originalFileName;
        FileUrl = fileUrl;
    }

    public static UserBanner New(
        UserBannerId id,
        UserId userId,
        string originalFileName,
        string fileUrl)
    => new(id, userId, originalFileName, fileUrl);

    public void Update(
        UserId userId,
        string originalFilename,
        string fileUrl)
    {
        UserId = userId;
        OriginalFileName = originalFilename;
        FileUrl = fileUrl;
    }
}