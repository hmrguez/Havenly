namespace Havenly.Api.Users;

public class UserQuery
{
    public List<User> GetAllUsers()
    {
        return new List<User>
        {
            new User { Name = "User1", Age = 30 },
            new User { Name = "User2", Age = 25 },
            new User { Name = "User3", Age = 35 },
        };
    }
}

public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}