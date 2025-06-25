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

            builder.Property(x => x.Validade)
                .HasColumnName("Validade")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.Emissao)
                .HasColumnName("Emissao")
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .HasColumnName("ValorTotal")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Observacao)
                .HasColumnName("Observacao")
                .HasMaxLength(1000)
                .IsRequired(false);

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .HasConversion<int>()
                .IsRequired();

            builder.Property(x => x.CodigoAutor)
                .HasColumnName("CodigoAutor")
                .IsRequired();

            builder.Property(x => x.CodigoCliente)
                .HasColumnName("CodigoCliente")
                .IsRequired();

            // Configuração do relacionamento com ItemOrcamento
            builder.HasMany(x => x.Itens)
                .WithOne()
                .HasForeignKey("CodigoOrcamento")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
