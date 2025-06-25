using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps;

public class ItensOrcamentoPecaMap : IEntityTypeConfiguration<ItemOrcamentoPeca>
{
    public void Configure(EntityTypeBuilder<ItemOrcamentoPeca> builder)
    {
        builder.ToTable("item_orcamento_peca");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("CodigoPecaOrcamento")
            .ValueGeneratedNever();

        builder.Property(x => x.CodigoItem)
            .HasColumnName("CodigoItem")
            .IsRequired();

        builder.Property(x => x.CodigoPeca)
            .HasColumnName("CodigoPeca")
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

        // Associação com ItemOrcamento (relacionamento muitos-para-um)
        builder.HasOne(x => x.Item)
            .WithMany()
            .HasForeignKey(x => x.CodigoItem)
            .OnDelete(DeleteBehavior.Cascade);

        // Associação com Peca (relacionamento muitos-para-um)
        builder.HasOne(x => x.Peca)
            .WithMany()
            .HasForeignKey(x => x.CodigoPeca)
            .OnDelete(DeleteBehavior.Restrict);
    }
}