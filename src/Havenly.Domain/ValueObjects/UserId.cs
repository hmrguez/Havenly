using Domain.Common.Models;

namespace Domain.ValueObjects;

public class UserId(Guid value) : ValueObject
{
    public Guid Value { get; set; } = value;

    public static UserId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}