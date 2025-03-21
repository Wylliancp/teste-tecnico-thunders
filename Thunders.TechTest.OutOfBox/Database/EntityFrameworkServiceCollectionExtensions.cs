using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Thunders.TechTest.OutOfBox.Database
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ThundersTechTestDb"));
            });

            return services;
        }
        
        public static IServiceCollection AddPostgresDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>((options) =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ThundersTechTestDb"),                    
                    b => b.MigrationsAssembly("Thunders.TechTest.infrastructure")
                );
            });

            return services;
        }
    }
}
