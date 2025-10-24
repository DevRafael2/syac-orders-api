namespace Syac.Orders.Core.Application.Dtos.Entities.Products
{
    /// <summary>
    /// Dto de saluda para productos
    /// </summary>
    public class OutProduct
    {
        /// <summary>
        /// Id del producto
        /// </summary>
        public short Id { get; set; }
    
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Name { get; set; }
    
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }
    }
}
