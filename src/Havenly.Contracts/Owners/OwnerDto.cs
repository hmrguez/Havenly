using Havenly.Contracts.Users;

namespace Havenly.Contracts.Owners;

public class OwnerDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserDto User { get; set; }
}