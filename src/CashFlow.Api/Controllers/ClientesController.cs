using CashFlow.Application.UseCases.Clientes;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IClientesService service)
        {
            return Ok(await service.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(
            [FromBody] Cliente request,
            [FromServices] IClientesService service)
        {
            await service.Create(request);

            return Created("", new {});
        }
    }
}
