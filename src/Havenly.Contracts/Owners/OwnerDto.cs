using Havenly.Contracts.Properties;
using Havenly.Contracts.Users;

namespace Havenly.Contracts.Owners;

public class OwnerDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserDto? User { get; set; }
    public List<PropertyDto>? Properties { get; set; }
}