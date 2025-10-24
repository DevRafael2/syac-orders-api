using Syac.Orders.Core.Domain.Primitives;

namespace Syac.Orders.Core.Domain.Entities
{
    /// <summary>
    /// Entidad de ordenes
    /// </summary>
    public class Order : EntityRoot<Guid>
    {
        /// <summary>
        /// Id del Cliente
        /// </summary>
        public Guid CustomerId { get; set; }
    
        /// <summary>
        /// Fecha y hora en la que se creo la orden
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Estado de la orden, siendo null en proceso, false cancelada, true confirmada
        /// </summary>
        public bool? State { get; set; }

        /// <summary>
        /// Cliente al que se le realizó la orden
        /// </summary>
        public virtual Customer? Customer { get; set; }

        /// <summary>
        /// Productos relacionados
        /// </summary>
        public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
