using Havenly.Api.Amenities;
using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Tenants;

public static class TenantConfig
{
    public static IRequestExecutorBuilder AddTenants(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<TenantMutation>()
            .AddType<TenantQuery>();
    }
}