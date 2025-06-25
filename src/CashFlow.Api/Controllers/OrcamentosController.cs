using CashFlow.Application.UseCases.Orcamentos;
using CashFlow.Application.UseCases.Orcamentos.Itens;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Requests.Orcamento;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrcamentosController : ControllerBase
    {
        private readonly IOrcamentoService _service;
        public OrcamentosController(IOrcamentoService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateOrcamentoRequest request)
        {
            var id = await _service.Create(request);

            return Created("", id);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrcamentoRequest request)
        {
            await _service.Update(id, request);

            return Ok("");
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Orcamento>), StatusCodes.Status200OK)]
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
            var valores = await service.Create(request);

            return Created("", valores);
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

        // [HttpGet]
        // [Route("itens/{id}/valores")]
        // [ProducesResponseType(typeof(List<ItemOrcamentoValor>), StatusCodes.Status200OK)]
        // public async Task<IActionResult> GetValoresItemOrcamento(
        //     [FromRoute] Guid id,
        //     [FromServices] IItensOrcamentoService service)
        // {
        //     return Ok(await service.GetValoresItemOrcamento(id));
        // }

        [HttpPut]
        [Route("{id}/itens")]
        public async Task<IActionResult> UpdateItemOrcamento(
            [FromRoute] Guid id,
            [FromBody] UpdateItemOrcamentoRequest request,
            [FromServices] IItensOrcamentoService service)
        {
            await service.UpdateItemOrcamento(id, request);

            return Ok();
        }
    }
}
