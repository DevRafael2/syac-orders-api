using Syac.Orders.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Domain.Entities
{
    /// <summary>
    /// Entidad de productos
    /// </summary>
    public class Product : EntityRoot<short>
    {
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Precio o costo del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Ordenees donde se solicitó el producto
        /// </summary>
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
