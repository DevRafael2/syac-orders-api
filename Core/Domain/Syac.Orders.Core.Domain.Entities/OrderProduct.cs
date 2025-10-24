using Syac.Orders.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Domain.Entities
{
    /// <summary>
    /// Entidad que relaciona ordenes con sus respectivos productos
    /// </summary>
    public class OrderProduct : EntityRoot<long>
    {
        /// <summary>
        /// Id del producto relacionado a la orden
        /// </summary>
        public short ProductId { get; set; }

        /// <summary>
        /// Id de la orden
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Cantidad solicitada de dicho producto
        /// </summary>
        public short Amount { get; set; }

        /// <summary>
        /// Orden
        /// </summary>
        public virtual Order? Order { get; set; }
    
        /// <summary>
        /// Producto relacionado
        /// </summary>
        public virtual Product? Product { get; set; }
    }
}
