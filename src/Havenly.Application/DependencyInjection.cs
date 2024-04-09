using FluentValidation;
using Havenly.Application.Authentication;
using Havenly.Application.Authentication.Services;
using Havenly.Application.Authentication.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Havenly.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();


        // Validators
        services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();
        services.AddScoped<IValidator<LoginRequest>, LoginValidator>();

        return services;
    }
}