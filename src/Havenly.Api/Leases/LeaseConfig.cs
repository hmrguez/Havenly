using Havenly.Api.Amenities;
using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Leases;

public static class LeaseConfig
{
    public static IRequestExecutorBuilder AddLeases(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<LeaseQuery>()
            .AddType<LeaseMutation>();
    }
}