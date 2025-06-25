using System.Threading.Tasks;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Pecas;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class PecasRepository : IPecasRepository
    {
        private readonly CashFlowDbContext _db;
        public PecasRepository(CashFlowDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> Create(Peca request)
        {
            request.Id = Guid.NewGuid();

            await _db.Pecas.AddAsync(request);

            return request.Id;
        }

        public async Task<List<Peca>> GetAll()
        {
            return await _db.Pecas.AsNoTracking().ToListAsync();
        }

        public async Task<Peca?> GetById(Guid id)
        {
            return await _db.Pecas.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Peca request)
        {
            _db.Pecas.Update(request);
        }

    }
}
