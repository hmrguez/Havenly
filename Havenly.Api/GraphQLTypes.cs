using AppAny.HotChocolate.FluentValidation;
using Havenly.Api.Authentication;
using Havenly.Api.Users;

namespace Havenly.Api;

public static class GraphQlTypes
{
    public static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddFluentValidation()
            .AddUsers()
            .AddAuthentication();

        return services;
    }
}