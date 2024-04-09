using Domain.Common.Models;

namespace Domain.ValueObjects;

public class OwnerId(Guid value) : ValueObject
{
    public Guid Value { get; set; } = value;

    public static OwnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}