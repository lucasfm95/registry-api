using RegistryApi.Core.Services;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Repository;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Repositories;
using RegistryApi.Repository.Repositories.Interfaces;

namespace RegistryApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddServicesResolveDependencies(this IServiceCollection services)
        {
            services.AddHttpClient<HttpService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IHttpService, HttpService>();

            return services;   
        }

        public static IServiceCollection AddRepositoriesResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbClientFactory, MongoDbClientFactory>();
            if ((Environment.GetEnvironmentVariable("MAIN_DATABASE") ?? "mongodb").Equals("mongodb"))
            {
                services.AddSingleton<ICustomerRepository, CustomerRepository>();
            }
            else
            {
                services.AddSingleton<ICustomerRepository, CustomerSqlRepository>();
            }
            
            services.AddSingleton<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}
