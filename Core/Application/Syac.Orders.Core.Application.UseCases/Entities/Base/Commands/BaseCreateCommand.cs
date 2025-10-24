using MapsterMapper;
using MediatR;
using Syac.Orders.Core.Application.Interfaces.UnitOfWork;
using Syac.Orders.Core.Domain.Primitives;

namespace Syac.Orders.Core.Application.UseCases.Entities.Base.Commands
{
    /// <summary>
    /// Request base para comando de creación de entidades
    /// </summary>
    /// <param name="entity">Entidad (dto)</param>
    /// <typeparam name="TInDto">Tipo del dto</typeparam>
    /// <typeparam name="TOutDto">Tipo del dto de salida</typeparam>
    public record BaseCreateRequest<TInDto, TOutDto>(TInDto Entity)
        : IRequest<ResponseApiData<TOutDto>>;

    /// <summary>
    /// Comando de creación para entidades
    /// </summary>
    /// <typeparam name="TEntity">Entidad original</typeparam>
    /// <typeparam name="TId">Tipo de id de la entidad</typeparam>
    /// <typeparam name="TInDto">Dto de entrada</typeparam>
    /// <typeparam name="TOutDto">Dto de salida</typeparam>
    public abstract class BaseCreateCommand<TEntity, TId, TInDto, TOutDto, TRequest>(
        IUnitOfWork unitOfWork,
        IMapper mapper) :
        IRequestHandler<TRequest, ResponseApiData<TOutDto>>
        where TEntity : EntityRoot<TId>, new()
        where TRequest : BaseCreateRequest<TInDto, TOutDto>
    {
        /// <summary>
        /// Handler para crear entidades
        /// </summary>
        /// <param name="request">request del comando</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Retorna respuesta con información de la operación</returns>
        public virtual async Task<ResponseApiData<TOutDto>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<TEntity, TId>();
            if (request.Entity is null)
                return new() { StatusResponse = StatusResponse.BadRequest, Errors = ["No proporciono información"] };

            var createEntity = mapper.Map<TEntity>(request.Entity);

            var entityCreate = await repository.CreateAsync(createEntity);
            await unitOfWork.CompleteAsync();
            var entityOutCreate = mapper.Map<TOutDto>(entityCreate);
            return new()
            {
                Data = entityOutCreate,
                StatusResponse = StatusResponse.Ok,
                Message = "Registro creado correctamente",
            };
        }
    }
}
