using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    internal class PecasMap : IEntityTypeConfiguration<Peca>
    {
        public void Configure(EntityTypeBuilder<Peca> builder)
        {
            builder.ToTable("peca");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CodigoPeca")
                .ValueGeneratedNever();

            builder.Property(x => x.Descricao);

            builder.Property(x => x.TamanhoPeca);

            builder.Property(x => x.Porcentagem);
        }
    }
}
