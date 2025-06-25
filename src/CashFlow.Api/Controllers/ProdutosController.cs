
using CashFlow.Application.UseCases.Produtos;
using CashFlow.Communication.Requests.Produtos;
using CashFlow.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController(IProdutosService produtosService) : ControllerBase
{
    private readonly IProdutosService _service = produtosService;

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<Guid>> CreateProduct([FromBody] CreateProdutoRequest request)
    {
        var id = await _service.CreateProduto(request);

        return Created("", id);
    }

    [HttpGet]
    // [ProducesResponseType(typeof(ActionResult<IEnumerable<Produto>>), StatusCode = StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Produto>>> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Produto?>> GetById([FromRoute] Guid id)
    {
        var produto = await _service.GetById(id);

        if (produto is null)
            return NotFound();

        return Ok(produto);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreateProdutoRequest request)
    {
        await _service.UpdateProduto(new UpdateProdutoRequest(id, request.Nome, request.Descricao, request.ValorBase, request.Ativo));

        return NoContent();
    }

    [HttpPost("{produtoId:guid}/partes")]
    public async Task<IActionResult> AddPartesDoProduto([FromRoute] Guid produtoId, [FromBody] List<AddParteProdutoRequest> partes)
    {
        await _service.AddPartesDoProduto(produtoId, partes);

        return NoContent();
    }
}
