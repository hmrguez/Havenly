using Havenly.Api.Amenities;
using Havenly.Api.Owners;
using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Owners;

public static class OwnerConfig
{
    public static IRequestExecutorBuilder AddOwners(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<OwnerMutation>()
            .AddType<OwnerQuery>();
    }
}