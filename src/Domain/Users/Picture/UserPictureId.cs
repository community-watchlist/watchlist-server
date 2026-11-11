namespace Domain.Users.Picture;

public record UserPictureId(Guid Value)
{
    public static UserPictureId Empty = new UserPictureId(Guid.Empty);
    public static UserPictureId New() => new UserPictureId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}