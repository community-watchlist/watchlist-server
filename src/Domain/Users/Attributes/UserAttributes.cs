namespace Domain.Users.Attributes;

public class UserAttributes
{
    public string? BirthDate { get; set; }
    public string? Website { get; set; }
    public string? Location { get; set; }

    private UserAttributes(
        string? birthDate, 
        string? website, 
        string? location)
    {
        BirthDate = birthDate;
        Website = website;
        Location = location;
    }
    
    public static UserAttributes New(
        string? birthDate, 
        string? website, 
        string? location)
    => new(birthDate, website, location);

    public void Update(
        string? birthDate,
        string? website,
        string? location)
    {
        BirthDate = birthDate;
        Website = website;
        Location = location;
    }
}