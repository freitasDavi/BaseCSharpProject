using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    public class ClientesMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CodigoCliente")
                .ValueGeneratedNever();

            builder.Property(x => x.Nome);

            builder.Property(x => x.CNPJ);

            builder.Property(x => x.Email);

            builder.Property(x => x.Telefone);

            builder.Property(x => x.CEP);

            builder.Property(x => x.Rua);

            builder.Property(x => x.Estado);

            builder.Property(x => x.Cidade);
        }
    }
}
