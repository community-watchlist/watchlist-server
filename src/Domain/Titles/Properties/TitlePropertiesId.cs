namespace Domain.Titles.Properties;

public class TitlePropertiesId(Guid Value)
{
    public static TitlePropertiesId Empty = new TitlePropertiesId(Guid.Empty);
    public static TitlePropertiesId New() => new TitlePropertiesId(Guid.NewGuid());
    public override string ToString() => Value.ToString();
}