using Application.Interfaces.Repositories.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Extensions
{
    public static class IserviceCollectionExtensions

    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMappings();
            services.AddDbContext(configuration);
            services.AddRepositories();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(connectionString,
            //        builder => builder.CommandTimeout(30))); // Adjust timeout as needed
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient(typeof(IUnitofWork), typeof(UnitofWork))
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

    }
}
