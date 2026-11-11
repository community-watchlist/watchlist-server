namespace Domain.Genres;

public class Genre
{
    public GenreId Id { get; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Genre(GenreId id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public static Genre New(
        GenreId id,
        string name,
        DateTime createdAt)
        => new(id, name, DateTime.UtcNow);

    public void Update(string name)
    {
        Name = name;
    }
}