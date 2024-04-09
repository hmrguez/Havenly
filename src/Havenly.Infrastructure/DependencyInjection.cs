using Havenly.Application.Common.Interfaces.Authentication;
using Havenly.Application.Common.Interfaces.Persistence;
using Havenly.Application.Common.Interfaces.Services;
using Havenly.Infrastructure.Authentication;
using Havenly.Infrastructure.Persistence;
using Havenly.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Havenly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}