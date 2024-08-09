using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Clientes;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ClientesRepository : IClientesRepository
    {
        private readonly CashFlowDbContext _context;
        public ClientesRepository(CashFlowDbContext context)
        {
            _context = context;
        }

        public async Task Create(Cliente request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Cliente>> GetAll()
        {
            throw new NotImplementedException();
            //return await _context.Clientes.AsNoTracking().ToListAsync();
        }
    }
}
