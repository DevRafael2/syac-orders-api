using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Syac.Orders.Core.Application.Interfaces.Repositories;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Infraestructure.Persistence.Context;
using Syac.Orders.Core.Infraestructure.Persistence.Repositories;
using Syac.Orders.Core.Shared.Constants;

namespace Syac.Orders.Core.Infraestructure.Persistence
{
    /// <summary>
    /// Clase estatica para extender persistencia
    /// </summary>
    public static class SyacPersistenceServiceExtension
    {
        /// <summary>
        /// Metodo para agregar al contenedor de dependencias los servicios de persistencia
        /// </summary>
        /// <param name="services">Servicios</param>
        /// <param name="configuration">Configuracion (appsettings)</param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SyacOrdersDbContext>(e =>
            {
                e.UseSqlServer(configuration.GetConnectionString(AppKeys.DbConnectionSting));

#if DEBUG
                e.EnableSensitiveDataLogging();
                e.EnableDetailedErrors();
#endif
            });

            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
