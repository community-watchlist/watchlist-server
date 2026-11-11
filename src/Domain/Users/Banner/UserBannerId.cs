namespace Domain.Users.Banner;

public record UserBannerId(Guid Value)
{
    public static UserBannerId Empty = new(Guid.Empty);
    public static UserBannerId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}