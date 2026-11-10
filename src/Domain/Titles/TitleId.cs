namespace Domain.Titles;

public record TitleId(Guid Value) 
{
    public static TitleId Empty = new TitleId(Guid.Empty);
    public static TitleId New() => new TitleId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}