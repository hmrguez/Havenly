using Domain.Errors;
using Havenly.Api.Authentication;
using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Amenity;

public static class AmenityConfig
{
    public static IRequestExecutorBuilder AddAmenities(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<AmenityQuery>();
    }
}