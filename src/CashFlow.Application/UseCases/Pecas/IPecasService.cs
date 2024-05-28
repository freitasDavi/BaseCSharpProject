using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Pecas
{
    public interface IPecasService
    {
        Task<Guid> Create(Peca request);
        Task Update(Guid id, Peca request);
        Task<List<Peca>> GetAll();
        Task<Peca> GetById(Guid Guid);
        Task InsertValores(Guid codigoPeca, List<ValorPeca> valorPecas);
        Task InsertValor(Guid codigoPeca, ValorPeca valorPeca);
    }
}
