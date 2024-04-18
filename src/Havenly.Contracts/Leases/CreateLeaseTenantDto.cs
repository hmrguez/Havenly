using Domain.Enums;

namespace Havenly.Contracts.Leases;

public class CreateLeaseTenantDto
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string ContactInfo { get; set; }
    public Gender Gender { get; set; }
    public int AverageSalary { get; set; }
    public int Age { get; set; }
    public int Rent { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Deposit { get; set; }
    public Guid PropertyId { get; set; }
}