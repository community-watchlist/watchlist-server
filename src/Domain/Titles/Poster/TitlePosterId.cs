namespace Domain.Titles.Poster;

public record TitlePosterId(Guid Value)
{
    public static TitlePosterId Empty = new(Guid.Empty);
    public static TitlePosterId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}