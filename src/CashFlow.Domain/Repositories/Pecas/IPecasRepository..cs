using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Pecas
{
    public interface IPecasRepository
    {
        Task<int> Create(Peca request);
        void Update(Peca request);
        Task<List<Peca>> GetAll();
        Task<Peca?> GetById(int id);
        Task InsertValores(List<ValorPeca> valorPecas);
        Task InsertValor(ValorPeca valorPeca);
    }
}
