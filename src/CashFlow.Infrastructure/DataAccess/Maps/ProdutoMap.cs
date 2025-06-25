using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("CodigoProduto")
            .ValueGeneratedNever();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(x => x.ValorBase)
            .HasColumnName("ValorBase")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(x => x.Ativo)
            .HasColumnName("Ativo")
            .IsRequired();

        builder.HasMany(x => x.Composicoes)
            .WithOne()
            .HasForeignKey("CodigoProduto")
            .OnDelete(DeleteBehavior.Cascade);
    }
}