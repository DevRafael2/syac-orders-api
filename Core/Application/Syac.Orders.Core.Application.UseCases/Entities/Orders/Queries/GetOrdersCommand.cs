using MapsterMapper;
using Syac.Orders.Core.Application.Dtos.Entities.Orders;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Application.UseCases.Entities.Base.Queries;
using Syac.Orders.Core.Domain.Entities;
using Syac.Orders.Core.Domain.Primitives;
using System.Linq.Expressions;

namespace Syac.Orders.Core.Application.UseCases.Entities.Orders.Queries
{
    /// <summary>
    /// Request para obtener ordenes
    /// </summary>
    public class GetOrdersRequest : QueryParams<Order, OutOrderPaginate>
    {
        public override Expression<Func<Order, Order>> GetSelectExpression() => e => new Order
        {
            Id = e.Id,
            CreatedAt = e.CreatedAt,
            State = e.State,
            Customer = new() { Name = e.Customer!.Name }
        };

        public override Expression<Func<Order, bool>> GetWhereExpression() => e => true;
    }

    public class GetOrdersCommand(IUnitOfWork unitOfWork, IMapper mapper) : 
        BaseGetQuery<Order, Guid, GetOrdersRequest, OutOrderPaginate>(unitOfWork, mapper);
}
