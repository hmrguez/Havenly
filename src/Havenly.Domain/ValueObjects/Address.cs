using Domain.Common.Models;

namespace Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }


    public Address(string street, string city, string zipCode)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Street, City, ZipCode];
    }
}