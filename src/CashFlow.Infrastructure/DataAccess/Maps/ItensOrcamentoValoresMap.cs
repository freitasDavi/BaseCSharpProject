using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    public class ItensOrcamentoValoresMap : IEntityTypeConfiguration<ItemOrcamentoValor>
    {
        public void Configure(EntityTypeBuilder<ItemOrcamentoValor> builder)
        {
            builder.ToTable("itemorcamentovalor");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("CodigoItemOrcamentoValores")
                .ValueGeneratedNever();

            builder.Property(x => x.CodigoItemOrcamento);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Valor);
        }
    }
}
