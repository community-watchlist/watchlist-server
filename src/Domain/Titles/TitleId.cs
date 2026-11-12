namespace Domain.Titles;

public record TitleId(Guid Value) 
{
    public static TitleId Empty = new(Guid.Empty);
    public static TitleId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}