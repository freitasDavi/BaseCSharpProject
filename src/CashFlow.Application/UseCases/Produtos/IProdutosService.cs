
using CashFlow.Communication.Requests.Produtos;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Produtos;

public interface IProdutosService
{
    Task<Guid> CreateProduto(CreateProdutoRequest request);
    Task<IEnumerable<Produto>> GetAll();
    Task<Produto?> GetById(Guid id);
    Task UpdateProduto(UpdateProdutoRequest request);
    Task AddPartesDoProduto(Guid produtoId, List<AddParteProdutoRequest> partes);
}