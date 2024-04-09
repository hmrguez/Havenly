using Domain.Common.Models;
using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Owner : AggregateRoot<OwnerId>
{
    public UserId UserId { get; set; }
    public User User { get; set; } = null!;

    public List<Property> Type { get; set; } = [];

    private Owner(OwnerId id, UserId userId) : base(id)
    {
        UserId = userId;
    }

    public static Owner Create(UserId userId)
    {
        return new Owner(OwnerId.CreateUnique(), userId);
    }
}