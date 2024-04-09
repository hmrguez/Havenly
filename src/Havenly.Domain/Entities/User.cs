using Domain.Aggregates;
using Domain.Common.Models;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : Entity<UserId>
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public bool IsOwner { get; set; }
    public string ContactInfo { get; set; }


    public User()
    {
    }


    private User(UserId id, string name, string password, string email, bool isOwner, string contactInfo) : base(id)
    {
        Name = name;
        Password = password;
        Email = email;
        IsOwner = isOwner;
        ContactInfo = contactInfo;
    }

    public static User Create(string name, string password, string email, bool isOwner, string contactInfo)
    {
        return new User(UserId.CreateUnique(), name, password, email, isOwner, contactInfo);
    }
}