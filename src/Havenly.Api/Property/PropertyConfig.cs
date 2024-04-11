using Domain.ValueObjects;
using HotChocolate.Execution.Configuration;

// ReSharper disable once CheckNamespace
namespace Havenly.Api.Properties;

public static class PropertyConfig
{
    public static IRequestExecutorBuilder AddProperties(this IRequestExecutorBuilder builder)
    {
        return builder
            .AddType<PropertyMutation>()
            .AddType<PropertyQuery>();
    }
}