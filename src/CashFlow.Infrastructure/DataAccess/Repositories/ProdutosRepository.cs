


using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ProdutosRepository(CashFlowDbContext dbContext) : IProdutosRepository
{
    private readonly CashFlowDbContext _dbContext = dbContext;
    public async Task<Guid> Create(Produto request)
    {
        await _dbContext.Produtos.AddAsync(request);

        return request.Id;
    }

    public void Delete(Produto request)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Produto>> GetAll()
    {
        return await _dbContext.Produtos.AsNoTracking().ToListAsync();
    }

    public async Task<Produto?> GetById(Guid id)
    {
        return await _dbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Produto request)
    {
        throw new NotImplementedException();
    }
}