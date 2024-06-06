using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Clientes
{
    public interface IClientesService
    {
        Task Create(Cliente request);
        Task<List<Cliente>> GetAll();
    }
}
