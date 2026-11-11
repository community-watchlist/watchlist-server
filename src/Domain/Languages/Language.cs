namespace Domain.Languages;

public class Language
{
    public LanguageCode Code { get; }
    public string Name { get; private set; }

    private Language(LanguageCode code, string name)
    {
        Code = code;
        Name = name;
    }

    public static Language New(LanguageCode code, string name)
        => new(code, name);

    public void Update(string name)
    {
        Name = name;
    }
}