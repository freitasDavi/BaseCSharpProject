


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

    public async Task<List<Produto>> GetAll()
    {
        return await _dbContext.Produtos
            .AsNoTracking()
            .Include(p => p.Composicoes)
            .ToListAsync();
    }

    public async Task<Produto?> GetById(Guid id, bool asNoTracking = true)
    {
        if (asNoTracking)
        {
            return await _dbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        return await _dbContext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Produto request)
    {
        _dbContext.Produtos.Update(request);
    }

    public async Task AddPartesDoProduto(List<ComposicaoProduto> partes)
    {
        await _dbContext.ComposicoesProdutos.AddRangeAsync(partes);
    }
}