using Domain.Common.Models;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Tenant : AggregateRoot<TenantId>
{
    public UserId UserId { get; set; }
    public User User { get; set; } = null!;

    public int Deposit { get; set; }
    public int AverageSalary { get; set; }
    public int Age { get; set; }

    public Tenant(TenantId id, UserId userId, int age, int averageSalary, int deposit, string contactInfo) : base(id)
    {
        Age = age;
        Deposit = deposit;
        AverageSalary = averageSalary;
        UserId = userId;
    }
}