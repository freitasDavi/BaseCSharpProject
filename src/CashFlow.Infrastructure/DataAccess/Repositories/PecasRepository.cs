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
            //await _db.Pecas.AddAsync(request);
            throw new NotImplementedException();
            return request.Id;
        }

        public async Task<List<Peca>> GetAll()
        {
            throw new NotImplementedException();
            //return await _db.Pecas.AsNoTracking().ToListAsync();
        }

        public async Task<Peca?> GetById(Guid id)
        {
            throw new NotImplementedException();
            //return await _db.Pecas.AsNoTracking().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertValor(ValorPeca valorPeca)
        {
            valorPeca.Id = Guid.NewGuid();
            throw new NotImplementedException();
            //await _db.ValoresPecas.AddAsync(valorPeca);
        }

        public async Task InsertValores(List<ValorPeca> valorePecas)
        {
            throw new NotImplementedException();
            //await _db.ValoresPecas.AddRangeAsync(valorePecas); 
        }

        public void Update(Peca request)
        {
            throw new NotImplementedException();
            //_db.Pecas.Update(request);
        }

        public async Task<List<ValorPeca>> GetValoresPeca(Guid codigoPeca)
        {
            throw new NotImplementedException();
            //return await _db.ValoresPecas.Where(vp => vp.CodigoPeca == codigoPeca).ToListAsync();
        }
    }
}
