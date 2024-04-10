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

    public Tenant()
    {
    }

    private Tenant(TenantId id, UserId userId, int age, int averageSalary, int deposit) : base(id)
    {
        Age = age;
        Deposit = deposit;
        AverageSalary = averageSalary;
        UserId = userId;
    }

    public static Tenant Create(UserId userId, int age, int averageSalary, int deposit)
    {
        return new Tenant(TenantId.CreateUnique(), userId, age, averageSalary, deposit);
    }
}