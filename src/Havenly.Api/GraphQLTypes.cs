using AppAny.HotChocolate.FluentValidation;
using Havenly.Api.Amenities;
using Havenly.Api.Authentication;

namespace Havenly.Api;

public static class GraphQlTypes
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddFluentValidation()
            .AddQueryType(q => q.Name("Query"))
            .AddMutationType(q => q.Name("Mutation"))
            .AddAuthentication()
            .AddAmenities();

        return services;
    }
}