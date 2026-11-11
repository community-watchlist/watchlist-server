namespace Domain.Users.Picture;

public class UserPicture
{
    public UserPictureId Id { get; }
    public UserId UserId { get; private set; }
    public string OriginalFileName { get; private set; }
    public string FileUrl { get; private set; }

    private UserPicture(
        UserPictureId id, 
        UserId userId, 
        string originalFileName, 
        string fileUrl)
    {
        Id = id;
        UserId = userId;
        OriginalFileName = originalFileName;
        FileUrl = fileUrl;
    }
    
    public static UserPicture New(
        UserPictureId id, 
        UserId userId, 
        string originalFilename, 
        string fileUrl)
    => new(id, userId, originalFilename, fileUrl);
    
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