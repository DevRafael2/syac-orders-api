using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Domain.Primitives
{
    /// <summary>
    /// Entidad base con Id
    /// </summary>
    /// <typeparam name="TId">Tipo de id</typeparam>
    public class EntityRoot<TId>
    {
        /// <summary>
        /// Id de la entidad
        /// </summary>
        public TId? Id { get; set; }

        /// <summary>
        /// Indica si el registro se ha eliminado
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
