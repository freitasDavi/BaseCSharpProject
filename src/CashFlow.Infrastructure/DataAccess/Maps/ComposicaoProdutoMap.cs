using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps;

public class ComposicaoProdutoMap : IEntityTypeConfiguration<ComposicaoProduto>
{
    public void Configure(EntityTypeBuilder<ComposicaoProduto> builder)
    {
        builder.ToTable("composicao_produto");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("CodigoComposicaoProduto")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CodigoProduto)
            .HasColumnName("CodigoProduto")
            .IsRequired();

        builder.Property(x => x.CodigoPeca)
            .HasColumnName("CodigoPeca")
            .IsRequired();

        builder.Property(x => x.Quantidade)
            .HasColumnName("Quantidade")
            .IsRequired();

        builder.HasOne(x => x.Peca)
            .WithMany()
            .HasForeignKey(x => x.CodigoPeca)
            .OnDelete(DeleteBehavior.Restrict);
    }
}