using Syac.Orders.Core.Domain.Primitives;

namespace Syac.Orders.Core.Domain.Entities
{
    /// <summary>
    /// Entidad de cliente
    /// </summary>
    public class Customer : EntityRoot<Guid>
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Correo del cliente
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Identificación del cliente
        /// </summary>
        public long? IdentityNumber { get; set; }
    
        /// <summary>
        /// Ordenes que ha realizado el cliente
        /// </summary>
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
