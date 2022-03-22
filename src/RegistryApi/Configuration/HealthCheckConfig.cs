using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using RegistryApi.Repository.Factory;
using System.Net.Mime;
using System.Text.Json;

namespace RegistryApi.Configuration
{
    public static class HealthCheckConfig
    {
        public static IServiceCollection AddHealthCheckConfig(this IServiceCollection services)
        {
            services
                .AddHealthChecks()
                .AddMongoDb(MongoDbSettings.ConnectionString, name: "mongodb");

            return services;
        }
    }
}
