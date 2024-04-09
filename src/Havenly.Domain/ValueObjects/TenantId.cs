using Domain.Common.Models;

namespace Domain.ValueObjects;

public class TenantId(Guid value) : ValueObject
{
    public Guid Value { get; set; } = value;

    public static TenantId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}