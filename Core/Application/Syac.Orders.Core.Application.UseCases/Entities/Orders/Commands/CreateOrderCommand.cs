using MapsterMapper;
using Syac.Orders.Core.Application.Dtos.Entities.Orders;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Application.UseCases.Entities.Base.Commands;
using Syac.Orders.Core.Domain.Entities;

namespace Syac.Orders.Core.Application.UseCases.Entities.Orders.Commands
{
    /// <summary>
    /// Request para crear una orden
    /// </summary>
    /// <param name="Entity">Dto de entrada</param>
    public record CreateOrderRequest(InOrder Entity) : BaseCreateRequest<InOrder, OutSampleOrder>(Entity);

    /// <summary>
    /// Comando de creación de ordenes
    /// </summary>
    /// <param name="unitOfWork">Unidad de trabajo</param>
    /// <param name="mapper">Mappster</param>
    public class CreateOrderCommand(IUnitOfWork unitOfWork, IMapper mapper) : 
        BaseCreateCommand<Order, Guid, InOrder, OutSampleOrder, CreateOrderRequest>(unitOfWork, mapper);
}
