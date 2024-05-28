using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Pecas
{
    public interface IPecasService
    {
        Task<int> Create(Peca request);
        Task Update(int id, Peca request);
        Task<List<Peca>> GetAll();
        Task<Peca> GetById(int id);
        Task InsertValores(int codigoPeca, List<ValorPeca> valorPecas);
        Task InsertValor(int codigoPeca, ValorPeca valorPeca);
    }
}
