using MediatR;
using Microsoft.AspNetCore.Mvc;
using Syac.Orders.Core.Application.UseCases.Entities.Products.Queries;

namespace Syac.Orders.Web.Api.Controllers.V1
{
    /// <summary>
    /// Controlador de productos
    /// </summary>
    /// <param name="sender">Sender de mediatR</param>
    [ApiController, Route("api/v1/products")]
    public class ProductController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Endpoint para obtener productos
        /// </summary>
        /// <param name="productParams">Queryparams de productos</param>
        /// <returns>Retorna respuesta paginada con productos</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]GetProductsRequest productParams)
        {
            var result = await sender.Send(productParams);
            return StatusCode((int)result.StatusResponse, productParams);
        }
    }
}
