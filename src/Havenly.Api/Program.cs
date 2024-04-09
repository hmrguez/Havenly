using Havenly.Api;
using Havenly.Api.Middleware;
using Havenly.Application;
using Havenly.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddLogging()
        .AddSingleton<IErrorFilter, LogErrorFilter>()
        .AddGraphQl();
}

var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapGraphQL();
    app.Run();
}