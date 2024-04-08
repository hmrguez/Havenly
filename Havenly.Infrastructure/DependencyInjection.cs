using Havenly.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace Havenly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}