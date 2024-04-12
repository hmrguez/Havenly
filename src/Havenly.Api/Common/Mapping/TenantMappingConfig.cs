using Domain.Aggregates;
using Domain.Entities;
using Domain.ValueObjects;
using Havenly.Contracts.Tenants;
using Havenly.Contracts.Users;
using Mapster;

namespace Havenly.Api.Common.Mapping;

public class TenantMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TenantDto, Tenant>().MapWith(src =>
            new Tenant
            {
                Age = src.Age,
                AverageSalary = src.AverageSalary,
                Gender = src.Gender,
                Id = new TenantId(src.Id),
                User = src.User.Adapt<User>(),
                UserId = new UserId(src.UserId)
            });

        config.NewConfig<Tenant, TenantDto>().MapWith(src =>
            new TenantDto
            {
                Age = src.Age,
                AverageSalary = src.AverageSalary,
                Gender = src.Gender,
                Id = src.Id.Value,
                User = src.User.Adapt<UserDto>(),
                UserId = src.UserId.Value
            });
    }
}