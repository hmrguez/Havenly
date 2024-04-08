using Havenly.Api.Authentication;
using Havenly.Api.Users;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services
        .AddGraphQLServer()
        .AddQueryType<UserQuery>()
        .AddMutationType<AuthenticationMutation>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapGraphQL();

    app.Run();
}