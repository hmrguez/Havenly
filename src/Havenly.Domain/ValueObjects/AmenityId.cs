using Domain.Common.Models;

namespace Domain.ValueObjects;

public class AmenityId(Guid value) : ValueObject
{
    public Guid Value { get; set; } = value;

    public static AmenityId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}