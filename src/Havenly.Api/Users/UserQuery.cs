namespace Havenly.Api.Users;

[ExtendObjectType("Query")]
public class UserQuery
{
    public List<User> GetAllUsers()
    {
        return new List<User>
        {
            new() { Name = "User1", Age = 30 },
            new() { Name = "User2", Age = 25 },
            new() { Name = "User3", Age = 35 }
        };
    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}