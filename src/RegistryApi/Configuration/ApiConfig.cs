using System.Text.Json.Serialization;

namespace RegistryApi.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddControllersConfig(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull); ;

            return services;
        }
    }
}
