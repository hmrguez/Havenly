using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Authentication;

public static class AuthenticationTypes
{
    public static IRequestExecutorBuilder AddAuthentication(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddMutationType<AuthenticationMutation>();
    }
}