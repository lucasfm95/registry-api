using RegistryApi.Core.Services;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Repository;
using RegistryApi.Repository.Interfaces;

namespace RegistryApi.IoC
{
    public static class SettingsServiceCollection
    {
        public static void AddServicesSettings(this IServiceCollection servicesCollection) {
            servicesCollection.AddTransient<ICustomerService, CustomerService>();
        }

        public static void AddRespositorySettings(this IServiceCollection servicesCollection) {
            servicesCollection.AddSingleton<ICustomerRepository, CustomerRespository>();
        }
    }
}
