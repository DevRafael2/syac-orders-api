using MapsterMapper;
using Syac.Orders.Core.Application.Dtos.Entities.Customers;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Application.UseCases.Entities.Base.Queries;
using Syac.Orders.Core.Domain.Entities;
using Syac.Orders.Core.Domain.Primitives;
using System.Linq.Expressions;

namespace Syac.Orders.Core.Application.UseCases.Entities.Customers.Queries
{
    /// <summary>
    /// Request para obtener clientes
    /// </summary>
    public class GetCustomerRequest : QueryParams<Customer, OutCustomer>
    {
        public override Expression<Func<Customer, Customer>> GetSelectExpression() => e => e;

        public override Expression<Func<Customer, bool>> GetWhereExpression() => e => true;
    }

    /// <summary>
    /// Query para obtener clientes
    /// </summary>
    public class GetCustomerQuery(IUnitOfWork unitOfWork, IMapper mapper) : 
        BaseGetQuery<Customer, Guid, GetCustomerRequest, OutCustomer>(unitOfWork, mapper);
}
