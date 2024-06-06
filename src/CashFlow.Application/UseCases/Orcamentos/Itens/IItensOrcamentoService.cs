using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Orcamentos.Itens
{
    public interface IItensOrcamentoService
    {
        Task<List<ItemOrcamento>> GetItens(Guid codigoOrcamento);
        Task<List<ItemOrcamentoValor>> Create(ItemOrcamento request);
        Task<List<ItemOrcamentoValor>> GetValoresItemOrcamento(Guid codigoItemOrcamento);
        Task UpdateItemOrcamento(Guid id, UpdateItemOrcamentoRequest request);
    }
}
