using CashFlow.Domain.Entities;
using CashFlow.Infrastructure.DataAccess.Maps;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public DbSet<Orcamento> Orcamentos { get; set; }
        public DbSet<ItemOrcamento> ItensOrcamento { get; set; }
        public DbSet<ItemOrcamentoPeca> ItensOrcamentoPeca { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Peca> Pecas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ComposicaoProduto> ComposicoesProdutos { get; set; }

        public CashFlowDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientesMap());
            modelBuilder.ApplyConfiguration(new PecasMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ComposicaoProdutoMap());
            modelBuilder.ApplyConfiguration(new OrcamentosMap());
            modelBuilder.ApplyConfiguration(new ItensOrcamentoMap());
            modelBuilder.ApplyConfiguration(new ItensOrcamentoPecaMap());
        }
    }
}
