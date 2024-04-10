using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Amenities;

public static class AmenityConfig
{
    public static IRequestExecutorBuilder AddAmenities(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<AmenityQuery>()
            .AddType<AmenityMutation>();
    }
}