using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Contracts.Owners;
using Havenly.Contracts.Properties;
using Havenly.Contracts.Tenants;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class OwnerMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Owner, OwnerDto>().MapWith(src => new OwnerDto
        {
            Id = src.Id.Value,
            Properties = src.Properties.Adapt<List<PropertyDto>>(),
            ContactInfo = src.User.ContactInfo,
            Email = src.User.Email,
            Name = src.User.Name,
            UserId = src.UserId.Value
        });

        config.NewConfig<OwnerDto, Owner>().MapWith(src => new Owner
        {
            Id = new OwnerId(src.Id),
            Properties = src.Properties.Adapt<List<Property>>(),
            UserId = new UserId(src.UserId)
        });
    }
}