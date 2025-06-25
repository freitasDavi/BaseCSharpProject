using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Pecas
{
    public interface IPecasRepository
    {
        Task<Guid> Create(Peca request);
        void Update(Peca request);
        Task<List<Peca>> GetAll();
        Task<Peca?> GetById(Guid id);
    }
}
