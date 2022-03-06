FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -o /app/published-app

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/published-app /app

ENV ASPNETCORE_ENVIRONMENT=production
ENV CONNECTION_STRING_MONGODB=connectionString
ENV DATABASE_NAME=registry
ENV CUSTOMERS_COLLECTION_NAME=customers
EXPOSE 80

ENTRYPOINT [ "dotnet", "/app/RegistryApi.dll" ]
