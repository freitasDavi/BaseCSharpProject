
using CashFlow.Application.UseCases.Produtos;
using CashFlow.Communication.Requests.Produtos;
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
}
