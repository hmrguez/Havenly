using Domain.Common.Models;

namespace Domain.ValueObjects;

public class OwnerId : ValueObject
{
    public Guid Value { get; set; }

    private OwnerId(Guid value)
    {
        Value = value;
    }

    public static OwnerId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}