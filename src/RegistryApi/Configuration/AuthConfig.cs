using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RegistryApi.Configuration
{
    public static class AuthConfig
    {
        public static IServiceCollection AddAuthenticationAuth0Config(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = Environment.GetEnvironmentVariable("AUTH0_AUTHORITY");
                options.Audience = Environment.GetEnvironmentVariable("AUTH0_AUDIENCE");
            });

            return services;
        }
    }
}
