using AppAny.HotChocolate.FluentValidation;
using Havenly.Api.Amenities;
using Havenly.Api.Authentication;
using Havenly.Api.Owners;
using Havenly.Api.Properties;
using Havenly.Api.Tenants;

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
            .AddAmenities()
            .AddTenants()
            .AddOwners()
            .AddProperties()
            .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true);  

        return services;
    }
}