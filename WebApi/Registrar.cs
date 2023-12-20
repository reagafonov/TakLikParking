using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Services.Abstractions;
using Services.Repositories.Abstractions;
using Services.Implementations;
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
            return services.AddSingleton((IConfigurationRoot)configuration)
                .InstallServices()
                .ConfigureContext(applicationSettings.ConnectionString)
                .InstallRepositories();
        }
        
        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IBookingService, BookingService>()
                .AddTransient<IParkingService, ParkingService>()
                .AddTransient<IPersonService, PersonService>()
                .AddTransient<ICarService, CarService>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IParkingRepository, ParkingRepository>()
                .AddTransient<IBookingRepository, BookingRepository>()
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddTransient<ICarRepository, CarRepository>();
            return serviceCollection;
        }
    }
}