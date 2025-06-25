

using CashFlow.Communication.Requests.Produtos;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Produtos;
using CashFlow.Exception.ExceptionsBase;

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

    public async Task<IEnumerable<Produto>> GetAll()
    {
        return await _repository.GetAll();
    }

    public async Task<Produto?> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public async Task UpdateProduto(UpdateProdutoRequest request)
    {
        var produtoASerAtualizado = await _repository.GetById(request.Id, false) ?? throw new NotFoundException($"Produto não encontrado com o id {request.Id}");

        produtoASerAtualizado.Ativo = request.Ativo;
        produtoASerAtualizado.Descricao = request.Descricao;
        produtoASerAtualizado.ValorBase = request.ValorBase;
        produtoASerAtualizado.Nome = request.Nome;

        _repository.Update(produtoASerAtualizado);
        await _unitOfWork.Commit();
    }
}