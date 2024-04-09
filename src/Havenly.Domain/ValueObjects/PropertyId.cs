using Domain.Common.Models;

namespace Domain.ValueObjects;

public class PropertyId : ValueObject
{
    public Guid Value { get; set; }

    private PropertyId(Guid value)
    {
        Value = value;
    }

    public static PropertyId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}