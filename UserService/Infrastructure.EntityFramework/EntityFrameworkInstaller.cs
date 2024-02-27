using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.EntityFramework
{
    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
            string connectionString)
        {
            services
                .AddDbContext<DatabaseContext>(o => o
                    .UseLazyLoadingProxies() // lazy loading
                    .UseNpgsql(connectionString)
                );
            services.AddIdentityCore<User>(options=>
                    options.SignIn.RequireConfirmedAccount=true)
                .AddEntityFrameworkStores<DatabaseContext>();
            return services;
        }
    }
}