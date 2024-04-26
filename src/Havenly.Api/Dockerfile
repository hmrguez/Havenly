FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Havenly.Api/Havenly.Api.csproj", "src/Havenly.Api/"]
COPY ["src/Havenly.Application/Havenly.Application.csproj", "src/Havenly.Application/"]
COPY ["src/Havenly.Contracts/Havenly.Contracts.csproj", "src/Havenly.Contracts/"]
COPY ["src/Havenly.Domain/Havenly.Domain.csproj", "src/Havenly.Domain/"]
COPY ["src/Havenly.Infrastructure/Havenly.Infrastructure.csproj", "src/Havenly.Infrastructure/"]
RUN dotnet restore "src/Havenly.Api/Havenly.Api.csproj"
COPY . .
WORKDIR "/src/src/Havenly.Api"
RUN dotnet build "Havenly.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Havenly.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Havenly.Api.dll"]
