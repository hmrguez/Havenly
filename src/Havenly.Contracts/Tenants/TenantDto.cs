using Domain.Enums;
using Havenly.Contracts.Users;

namespace Havenly.Contracts.Tenants;

public class TenantDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactInfo { get; set; }
    public Gender Gender { get; set; }
    public int AverageSalary { get; set; }
    public int Age { get; set; }
}