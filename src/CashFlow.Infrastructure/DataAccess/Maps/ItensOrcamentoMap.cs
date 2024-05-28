using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    internal class ItensOrcamentoMap : IEntityTypeConfiguration<ItemOrcamento>
    {
        public void Configure(EntityTypeBuilder<ItemOrcamento> builder)
        {
            builder.ToTable("itemorcamento");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("CodigoItemOrcamento")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Descricao);
            builder.Property(x => x.Quantidade);
            builder.Property(x => x.CodigoOrcamento);
            builder.Property(x => x.CodigoPeca);
            builder.Property(x => x.Nome);
            builder.Property(x => x.ValorTotal);
        }
    }
}
