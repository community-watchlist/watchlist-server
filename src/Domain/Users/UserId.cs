namespace Domain.Users;

public record UserId(Guid Value)
{
    public static UserId Empty = new UserId(Guid.Empty);
    public static UserId New() => new UserId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}