using FluentValidation;
using Havenly.Application.Amenities;
using Havenly.Application.Authentication;
using Havenly.Application.Authentication.Services;
using Havenly.Application.Authentication.Validation;
using Havenly.Application.Leases;
using Havenly.Application.Owners;
using Havenly.Application.Properties;
using Havenly.Application.Tenants;
using Microsoft.Extensions.DependencyInjection;

namespace Havenly.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAmenityService, AmenityService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IOwnerService, OwnerService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<ILeaseService, LeaseService>();
        

        // Validators
        services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();
        services.AddScoped<IValidator<LoginRequest>, LoginValidator>();

        return services;
    }
}