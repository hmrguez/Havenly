using Domain.Common.Models;

namespace Domain.ValueObjects;

public class PropertyId(Guid value) : ValueObject
{
    public Guid Value { get; set; } = value;

    public static PropertyId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}