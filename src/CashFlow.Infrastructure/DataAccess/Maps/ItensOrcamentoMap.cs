using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    internal class ItensOrcamentoMap : IEntityTypeConfiguration<ItemOrcamento>
    {
        public void Configure(EntityTypeBuilder<ItemOrcamento> builder)
        {
            builder.ToTable("item_orcamento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CodigoItemOrcamento")
                .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Quantidade)
                .HasColumnName("Quantidade")
                .IsRequired();

            builder.Property(x => x.ValorUnitario)
                .HasColumnName("ValorUnitario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .HasColumnName("ValorTotal")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Desconto)
                .HasColumnName("Desconto")
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(x => x.CodigoOrcamento)
                .HasColumnName("CodigoOrcamento")
                .IsRequired();

            builder.Property(x => x.CodigoProduto)
                .HasColumnName("CodigoProduto")
                .IsRequired();

            builder.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.CodigoProduto)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Orcamento)
                .WithMany(o => o.Itens)
                .HasForeignKey(x => x.CodigoOrcamento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
