using Havenly.Api;
using Havenly.Api.Common.Mapping;
using Havenly.Application;
using Havenly.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);
{
    builder.Configuration
        .AddJsonFile("appsettings.secrets.json", optional: false, reloadOnChange: false);

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration)
        .AddLogging()
        .AddSingleton<IErrorFilter, LogErrorFilter>()
        .AddGraphQl()
        .AddMappings();

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigin");
    app.MapGraphQL();
    app.Run();
}