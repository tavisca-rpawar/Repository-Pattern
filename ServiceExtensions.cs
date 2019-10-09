using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Contracts;
using Repository;
namespace Entities
{
    public static class ServiceExtensions {
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("dev");
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
