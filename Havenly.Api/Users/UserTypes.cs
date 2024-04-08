using HotChocolate.Execution.Configuration;

namespace Havenly.Api.Users;

public static class UserTypes
{
    public static IRequestExecutorBuilder AddUsers(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddQueryType<UserQuery>();
    }
}