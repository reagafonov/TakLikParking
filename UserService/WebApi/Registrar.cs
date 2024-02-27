using Domain.Entities;
using Infrastructure.EntityFramework;
using Infrastructure.Repositories.Implementations;
using Services.Abstractions;
using Services.Contracts;
using Services.Repositories.Abstractions;
using Services.Implementations;
using WebApi.Contracts.Dtos;
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
                .AddTransient<IPersonService, PersonService>()
                //.AddTransient<ICommonCrudService<RoleDto, int>, CommonCrudService<RoleDto, Role, int>>();
                .AddTransient<ICommonCrudService<UserDTO,string>, CommonCrudService<UserDTO,User,string>>();
            return serviceCollection;
        }
        
        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IPersonRepository, PersonRepository>()
                .AddTransient(typeof(ICommonRepository<,>), typeof(CommonRepository<,>));
            return serviceCollection;
        }
    }
}