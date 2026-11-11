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
    //TODO: add language code
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
        DateTime createdAt)
    {
        Id = id;
        ClerkId = clerkId;
        Role = role;
        Username = username;
        DisplayName = displayName;
        Email = email;
        Bio = bio;
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
        UserAttributes? attributes = null)
    => new(id, clerkId, role, username, displayName, email, bio, DateTime.UtcNow)
    {
        Attributes = attributes
    };
    
    public void Update(
        string username, 
        string? displayName, 
        string email, 
        string? bio, 
        UserAttributes? attributes = null)
    {
        Username = username;
        DisplayName = displayName;
        Email = email;
        Bio = bio;
        Attributes = attributes;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public void UpdateLastSeen()
    {
        LastSeenAt = DateTime.UtcNow;
    }
    
    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
    }
}