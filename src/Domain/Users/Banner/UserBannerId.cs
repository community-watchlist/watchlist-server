namespace Domain.Users.Banner;

public record UserBannerId(Guid Value)
{
    public static UserBannerId Empty = new UserBannerId(Guid.Empty);
    public static UserBannerId New() => new UserBannerId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}