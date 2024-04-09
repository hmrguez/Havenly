using Domain.Common.Models;

namespace Domain.ValueObjects;

public class AmenityId : ValueObject
{
    public Guid Value { get; set; }

    private AmenityId(Guid value)
    {
        Value = value;
    }

    public static AmenityId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}