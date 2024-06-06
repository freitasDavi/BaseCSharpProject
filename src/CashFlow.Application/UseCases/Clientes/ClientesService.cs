using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Clientes;

namespace CashFlow.Application.UseCases.Clientes
{
    public class ClientesService : IClientesService
    {
        private readonly IClientesRepository _repository;
        public ClientesService(IClientesRepository repository) 
        {
            _repository = repository;
        }

        public async Task Create(Cliente request)
        {
            await _repository.Create(request);
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
