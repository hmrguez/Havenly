using Havenly.Api;
using Havenly.Application;
using Havenly.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddGraphQlTypes();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapGraphQL();

    app.Run();
}