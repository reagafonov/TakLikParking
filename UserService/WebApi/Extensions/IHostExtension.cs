using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class IHostExtensions
{
    public static IHost MigrateDbContext<T>(this IHost host) where T : DbContext
    {
        using (var scope = host.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<T>();
            db.Database.Migrate();
        }

        return host;
    }
}