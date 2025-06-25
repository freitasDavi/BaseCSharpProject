

using CashFlow.Communication.Requests.Produtos;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Produtos;

namespace CashFlow.Application.UseCases.Produtos;

public class ProdutosService(IProdutosRepository repository, IUnitOfWork unitOfWork) : IProdutosService
{
    private readonly IProdutosRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Guid> CreateProduto(CreateProdutoRequest request)
    {
        var produto = new Produto
        {
            Id = Guid.NewGuid(),
            Ativo = request.Ativo,
            Descricao = request.Descricao,
            ValorBase = request.ValorBase,
            Nome = request.Nome,
        };

        var insertedId = await _repository.Create(produto);
        await _unitOfWork.Commit();

        return insertedId;
    }
}