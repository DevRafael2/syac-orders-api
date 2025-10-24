namespace Syac.Orders.Core.Application.Dtos.Entities.Orders
{
    /// <summary>
    /// Dto simple de salida para ordenes
    /// </summary>
    public class OutSampleOrder
    {
        /// <summary>
        /// Id de la orden
        /// </summary>
        public Guid Id { get; set; } 

        /// <summary>
        /// Fecha de creación de la orden
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Dto de salida para ordenes
    /// </summary>
    public class OutOrder : OutSampleOrder
    {

    }

    public class OutOrderPaginate : OutSampleOrder
    {
        /// <summary>
        /// Estado del pedido
        /// </summary>
        public string? State { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string? CustomerName { get; set; }
    }
}
