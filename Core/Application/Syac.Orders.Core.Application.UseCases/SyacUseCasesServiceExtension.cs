using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Application.UseCases
{
    /// <summary>
    /// Clase extensiva para agregar casos de uso
    /// </summary>
    public static class SyacUseCasesServiceExtension
    {
        /// <summary>
        /// Metodo para agregar casos de uso al contenedor de dependencias
        /// </summary>
        /// <param name="services">Contenedor de dependencias</param>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddMediatR(e => e.RegisterServicesFromAssembly(typeof(SyacUseCasesServiceExtension).Assembly));

            return services;
        }
    }
}
