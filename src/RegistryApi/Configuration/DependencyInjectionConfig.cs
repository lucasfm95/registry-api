using RegistryApi.Core.Services;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Repository;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Interfaces;

namespace RegistryApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddServicesResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();

            return services;   
        }

        public static IServiceCollection AddRepositoriesResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbClientFactory, MongoDbClientFactory>();
            services.AddSingleton<ICustomerRepository, CustomerRespository>();

            return services;
        }
    }
}
