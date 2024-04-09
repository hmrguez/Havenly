using Domain.Common.Models;

namespace Domain.ValueObjects;

public class UserId : ValueObject
{
    public Guid Value { get; set; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Value];
    }
}