using Domain.Common.Models;

namespace Domain.ValueObjects;

public class TenantId : ValueObject
{
    public Guid Value { get; set; }

    private TenantId(Guid value)
    {
        Value = value;
    }

    public static TenantId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}