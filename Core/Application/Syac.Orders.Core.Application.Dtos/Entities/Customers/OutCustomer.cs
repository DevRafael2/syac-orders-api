using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Application.Dtos.Entities.Customers
{
    /// <summary>
    /// Dto de salida para clientes
    /// </summary>
    public class OutCustomer
    {
        /// <summary>
        /// Id del cliente
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Correo del cliente
        /// </summary>
        public string? Email { get; set; }
    
        /// <summary>
        /// Numero de identificación del cliente
        /// </summary>
        public long? IdentityNumber { get; set; }
    }
}
