using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syac.Orders.Core.Application.Dtos.Entities.Orders;
using Syac.Orders.Core.Application.UseCases.Entities.Orders.Commands;
using Syac.Orders.Core.Application.UseCases.Entities.Orders.Queries;

namespace Syac.Orders.Web.Api.Controllers.V1
{
    [ApiController, Route("api/v1/orders")]
    public class OrderController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Endpoint para obtener ordenes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetOrdersRequest orderParams)
        {
            var result = await sender.Send(orderParams);
            return StatusCode((int)result.StatusResponse, result);
        }


        /// <summary>
        /// Endpoint para creación de ordenes
        /// </summary>
        /// <param name="order">Orden</param>
        /// <returns>Retorna una respuesta relacionada al proceso</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(InOrder order)
        {
            var result = await sender.Send(new CreateOrderRequest(order));
            return StatusCode((int)result.StatusResponse, result);
        }

    }
}
