using Havenly.Api.Authentication;
using Havenly.Api.Users;
using Havenly.Application.Authentication;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

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