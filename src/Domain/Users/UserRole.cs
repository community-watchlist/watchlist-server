using Domain.Common;

namespace Domain.Users;

public static class UserRoleValues
{
    public const string Admin = "admin";
    public const string User = "user";
}

public class UserRole : ValueObject
{
    private string Value { get; }
    
    private UserRole(string value)
    {
        Value = value;
    }

    public static UserRole From(string value)
    {
        var role = new UserRole(value);
        
        if(!AllowedRoles.Contains(role))
        {
            throw new ArgumentException($"Invalid user role: {value}");
        }
        
        return role;
    }

    public static UserRole Admin => new(UserRoleValues.Admin);
    public static UserRole User => new(UserRoleValues.User);

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public override string ToString() => Value;
    
    private static IEnumerable<UserRole> AllowedRoles
    {
        get
        {
            yield return Admin;
            yield return User;
        }
    }
}