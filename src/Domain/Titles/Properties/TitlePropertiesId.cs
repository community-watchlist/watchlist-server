namespace Domain.Titles.Properties;

public record TitlePropertiesId(Guid Value)
{
    public static TitlePropertiesId Empty = new(Guid.Empty);
    public static TitlePropertiesId New() => new(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}