using Mapster;
using Syac.Orders.Core.Application.Dtos.Entities.Orders;
using Syac.Orders.Core.Domain.Entities;

namespace Syac.Orders.Core.Application.Mappers.Entities
{
    /// <summary>
    /// Mapeo de ordenes
    /// </summary>
    public static class OrdersMapper
    {
        /// <summary>
        /// Metodo estatico para agregar configuraciones de mapeo para orden 
        /// </summary>
        public static void AddOrdersMaps()
        {
            TypeAdapterConfig.GlobalSettings.NewConfig<InOrder, Order>()
                .Map(e => e.OrderProducts, e => (from o in e.OrderProducts
                                                 select new OrderProduct
                                                 {
                                                     ProductId = o.ProductId,
                                                     Amount = o.Amount
                                                 }).ToList());

            TypeAdapterConfig.GlobalSettings.NewConfig<Order, OutOrderPaginate>()
                .Map(e => e.State, e => e.State != null ? (e.State == true ? "Completado" : "Cancelado") : "En proceso" )
                .Map(e => e.CustomerName, e => e.Customer == null ? "" : e.Customer.Name);
        }
    }
}
