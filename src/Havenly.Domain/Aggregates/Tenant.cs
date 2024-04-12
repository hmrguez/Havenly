using Domain.Common.Models;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Tenant : AggregateRoot<TenantId>
{
    public UserId UserId { get; set; }
    public User User { get; set; } = null!;

    public Gender Gender { get; set; }
    public int AverageSalary { get; set; }
    public int Age { get; set; }

    public Tenant()
    {
    }

    private Tenant(TenantId id, UserId userId, int age, int averageSalary, Gender gender) : base(id)
    {
        Age = age;
        AverageSalary = averageSalary;
        UserId = userId;
        Gender = gender;
    }

    public static Tenant Create(UserId userId, int age, int averageSalary, Gender gender)
    {
        return new Tenant(TenantId.CreateUnique(), userId, age, averageSalary, gender);
    }
}