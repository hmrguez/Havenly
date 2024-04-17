using Havenly.Contracts.Properties;
using Havenly.Contracts.Users;

namespace Havenly.Contracts.Owners;

public class OwnerDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public string Email { get; set; }
    public List<PropertyDto>? Properties { get; set; }
}