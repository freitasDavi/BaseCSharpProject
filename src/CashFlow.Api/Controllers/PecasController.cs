using CashFlow.Application.UseCases.Pecas;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class PecasController : ControllerBase
    {
        private readonly IPecasService _pecasService;

        public PecasController(IPecasService pecasService)
        {
            _pecasService = pecasService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] Peca request)
        {
            var id = await _pecasService.Create(request);

            return Created("", id);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Peca>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var pecas = await _pecasService.GetAll();

            return Ok(pecas);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Peca), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne([FromRoute] Guid id)
        {
            var peca = await _pecasService.GetById(id);

            return Ok(peca);
        }
    }
}
