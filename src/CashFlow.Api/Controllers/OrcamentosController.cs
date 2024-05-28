using CashFlow.Application.UseCases.Orcamentos;
using CashFlow.Application.UseCases.Orcamentos.Itens;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentosController : ControllerBase
    {
        private readonly IOrcamentoService _service;
        public OrcamentosController(IOrcamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] Orcamento request)
        {
            var id = await _service.Create(request);

            return Created("", id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Orcamento>),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ProducesResponseType(typeof(Orcamento), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok(await _service.GetById(id));
        }

        [HttpPost]
        [Route("itens")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        public async Task<IActionResult> AddItem(
            [FromBody] ItemOrcamento request,
            [FromServices] IItensOrcamentoService service)
        {
            return Created("", await service.Create(request));
        }

        [HttpGet]
        [Route("{id}/itens")]
        [ProducesResponseType(typeof(List<ItemOrcamento>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItens(
            [FromRoute] Guid id,
            [FromServices] IItensOrcamentoService service)
        {
            return Ok(await service.GetItens(id));
        }
    }
}
