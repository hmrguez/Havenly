namespace Havenly.Contracts.Tenants;

public class TenantDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int Deposit { get; set; }
    public int AverageSalary { get; set; }
    public int Age { get; set; }
}