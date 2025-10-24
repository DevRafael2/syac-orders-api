namespace Syac.Orders.Core.Application.Dtos.Entities.Orders
{
    /// <summary>
    /// Dto de entrada para ordenes
    /// </summary>
    public class InOrder 
    {
        /// <summary>
        /// Id del Cliente
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Productos asociados a la orden
        /// </summary>
        public IEnumerable<InOrderProduct>? OrderProducts { get; set; }
    }


    /// <summary>
    /// Dto de entrada para productos de la orden
    /// </summary>
    public class InOrderProduct
    {
        /// <summary>
        /// Id del producto
        /// </summary>
        public short ProductId { get; set; }

        /// <summary>
        /// Cantidad del producto
        /// </summary>
        public short Amount { get; set; }
    }
}
