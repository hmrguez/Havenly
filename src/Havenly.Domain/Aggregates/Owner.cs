using Domain.Common.Models;
using Domain.ValueObjects;

namespace Domain.Aggregates;

public class Owner : AggregateRoot<OwnerId>
{
    public List<PropertyId> Type { get; set; }
}