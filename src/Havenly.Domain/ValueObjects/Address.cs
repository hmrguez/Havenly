using Domain.Common.Models;

namespace Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }


    public Address(string street, string city, string zipCode, string country)
    {
        Street = street;
        City = city;
        ZipCode = zipCode;
        Country = country;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        return [Street, City, ZipCode];
    }
}