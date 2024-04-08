using Havenly.Api.Authentication;
using Havenly.Api.Users;

namespace Havenly.Api;

public static class GraphQlTypes
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddUsers()
            .AddAuthentication();

        return services;
    }
}