namespace Havenly.Contracts.Users;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactInfo { get; set; }
    public bool IsOwner { get; set; }
}