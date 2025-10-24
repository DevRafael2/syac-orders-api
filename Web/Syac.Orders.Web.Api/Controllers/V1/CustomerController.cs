using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syac.Orders.Core.Application.UseCases.Entities.Customers.Queries;

namespace Syac.Orders.Web.Api.Controllers.V1
{
    /// <summary>
    /// Controlador de clientes
    /// </summary>
    /// <param name="sender">Sender de mediatR</param>
    [ApiController, Route("api/v1/customer")]
    public class CustomerController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Endpoint para obtener clientes
        /// </summary>
        /// <returns>Retorna respuesta paginada con clientes</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]GetCustomerRequest customerParams)
        {
            var result = await sender.Send(customerParams);
            return StatusCode((int)result.StatusResponse, result);
        }
    }
}
