namespace Domain.Titles.Poster;

public class TitlePosterId(Guid Value)
{
    public static TitlePosterId Empty = new TitlePosterId(Guid.Empty);
    public static TitlePosterId New() => new TitlePosterId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}