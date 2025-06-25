
using CashFlow.Communication.Requests.Produtos;

namespace CashFlow.Application.UseCases.Produtos;

public interface IProdutosService
{
    Task<Guid> CreateProduto(CreateProdutoRequest request);

}