using WebApi.Settings;

namespace WebApi
{
    /// <summary>
    /// Регистратор сервиса
    /// </summary>
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>()!;
            services.AddSingleton(applicationSettings);
            return services.AddSingleton((IConfigurationRoot)configuration);

        }
    }
}