using Domain.Languages;
using Domain.Users.Attributes;

namespace Domain.Users;

public class User
{
    public UserId Id { get; }
    public string ClerkId { get; private set; }
    public UserRole Role { get; private set; }
    public string Username { get; private set; }
    public string? DisplayName { get; private set; }
    public string Email { get; private set; }
    public string? Bio { get; private set; }
    public LanguageCode Language { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public DateTime? LastSeenAt { get; private set; }
    public UserAttributes? Attributes { get; private set; }
    
    private User(UserId id, 
        string clerkId, 
        UserRole role, 
        string username, 
        string? displayName, 
        string email, 
        string? bio, 
        LanguageCode language,
        DateTime createdAt)
    {
        Id = id;
        ClerkId = clerkId;
        Role = role;
        Username = username;
        DisplayName = displayName;
        Email = email;
        Bio = bio;
        Language = language;
        CreatedAt = createdAt;
    }
    
    public static User New(
        UserId id, 
        string clerkId, 
        UserRole role, 
        string username, 
        string? displayName, 
        string email, 
        string? bio, 
        LanguageCode? language,
        UserAttributes? attributes)
    => new(id, 
        clerkId, 
        role, 
        username, 
        displayName, 
        email, 
        bio,
        language ?? LanguageCode.English, 
        DateTime.UtcNow)
    {
        Attributes = attributes
    };
    
    public void Update(
        string username, 
        string? displayName, 
        string email, 
        string? bio, 
        LanguageCode? language,
        UserAttributes? attributes)
    {
        Username = username;
        DisplayName = displayName;
        Email = email;
        Bio = bio;
        Language = language ?? Language;
        Attributes = attributes;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateLastSeen()
    {
        LastSeenAt = DateTime.UtcNow;
    }
    
    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}