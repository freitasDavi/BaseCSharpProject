using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Clientes
{
    public interface IClientesRepository
    {
        Task Create(Cliente cliente);
        Task<List<Cliente>> GetAll();
    }
}
