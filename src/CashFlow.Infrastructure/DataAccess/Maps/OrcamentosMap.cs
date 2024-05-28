using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    public class OrcamentosMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.ToTable("Orcamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CodigoOrcamento")
                .ValueGeneratedNever();

            builder.Property(x => x.Emissao);
            builder.Property(x => x.Validade);
            builder.Property(x => x.ValorTotal);
            builder.Property(x => x.CodigoCliente);
        }
    }
}
