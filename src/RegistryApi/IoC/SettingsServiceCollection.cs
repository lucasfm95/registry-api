using RegistryApi.Core.Services;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Repository;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Interfaces;

namespace RegistryApi.IoC
{
    public static class SettingsServiceCollection
    {
        public static void AddServicesSettings(this IServiceCollection servicesCollection) {
            servicesCollection.AddTransient<ICustomerService, CustomerService>();
        }

        public static void AddRespositorySettings(this IServiceCollection servicesCollection) {
            servicesCollection.AddSingleton<IMongoDbClientFactory, MongoDbClientFactory>();
            servicesCollection.AddSingleton<ICustomerRepository, CustomerRespository>();
        }
    }
}
