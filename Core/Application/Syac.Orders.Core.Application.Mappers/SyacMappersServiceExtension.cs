using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Syac.Orders.Core.Application.Mappers.Entities;

namespace Syac.Orders.Core.Application.Mappers
{
    /// <summary>
    /// Clase extensiva para agregar mapeos
    /// </summary>
    public static class SyacMappersServiceExtension
    {
        /// <summary>
        /// Metodo para agregar configuraciones de mapeos
        /// </summary>
        /// <param name="services">Contenedor de dependencias</param>
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            OrdersMapper.AddOrdersMaps();
            services.AddSingleton(TypeAdapterConfig.GlobalSettings);
            services.AddMapster();
            return services;
        }
    }
}
