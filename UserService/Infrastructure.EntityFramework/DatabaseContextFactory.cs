using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework
{
    /// <summary>
    /// Фабрика для создания контекста БД, используется для механизма миграций
    /// </summary>
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        /// <summary>Creates a new instance of a derived context.</summary>
        /// <param name="args"> Arguments provided by the design-time service. </param>
        /// <returns> An instance of <typeparamref name="TContext" />. </returns>
        public DatabaseContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            var configuration = builder.Build();
            var connectionString = configuration["ConnectionString"];
            if (connectionString == null)
            {
                throw new Exception("Connection string is null");
            }
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            //dbContextOptionsBuilder.UseSqlServer(connectionString);
            dbContextOptionsBuilder.UseNpgsql(connectionString, opt => opt.MigrationsAssembly(GetType().Assembly.GetName().Name));
            return new DatabaseContext(dbContextOptionsBuilder.Options);
        }
    }
}