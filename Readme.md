# Havenly

## Docs

Main architecture docs are [here](./docs/architecture.md)

## Prerequisites

1. Angular
2. Node.js
3. Dotnet SDK
4. Docker
5. Minikube and KubeCTL
6. PostgresSQL

## How to start

1. Clone the repository
2. Run `npm install` in the `src/Havenly.Web` directory
3. Run `dotnet restore` in the `root` directory

4. Start a post
5. Create a file called `appsettings.secrets.json` in the `src/Havenly.Api` directory with the contents along these lines,
   using the connection string for your postgres DB:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=havenly;Username=your-user;Password=your-password"
  }
}
```

6. Run `npm run start` in the `src/Havenly.Web` directory
7. Run `dotnet run` in the `src/Havenly.Api` directory

## Docker and Kubernetes

> You should have started Docker and your minikube node

1. Run `docker build` in the `src/Havenly.Api` directory
2. Run `kubectl apply -f graphql-api.deploy.yaml` in the `infra` directory
