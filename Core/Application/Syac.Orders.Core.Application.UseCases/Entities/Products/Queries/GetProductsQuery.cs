using MapsterMapper;
using Syac.Orders.Core.Application.Dtos.Entities.Products;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Application.UseCases.Entities.Base.Queries;
using Syac.Orders.Core.Domain.Entities;
using Syac.Orders.Core.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Syac.Orders.Core.Application.UseCases.Entities.Products.Queries
{
    /// <summary>
    /// Request para obtener productos
    /// </summary>
    public class GetProductsRequest : QueryParams<Product, OutProduct>
    {
        public override Expression<Func<Product, Product>> GetSelectExpression() => e => e;

        public override Expression<Func<Product, bool>> GetWhereExpression() => e => true;
    }

    /// <summary>
    /// Query para obtener productos
    /// </summary>
    public class GetProductsQuery(IUnitOfWork unitOfWork, IMapper mapper) : 
        BaseGetQuery<Product, short, GetProductsRequest, OutProduct>(unitOfWork, mapper);
}
